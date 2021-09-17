#include "TextEditor.h"
#include <experimental/filesystem>
#include <regex>

//======================================<LOW_LEVEL_EDITOR>======================================
LowLevelEditor::LowLevelEditor() {}
LowLevelEditor::~LowLevelEditor()
{
	for (size_t i = 0; i < files.size(); i++)
	{
		delete files[i];
	}
	files.clear();
}

//Get original file from files vector
File* LowLevelEditor::get_original()
{
	File* ret = NULL;

	for (size_t i = 0; i < files.size(); i++)
	{
		if (files[i]->is_original() == true)
		{
			ret = files[i];
			break;
		}
	}
	return (ret);
}

//create new file
string LowLevelEditor::create_new(string name, string postfix)
{
	size_t ind = 1;

	size_t ext_ind = name.find_last_of(".");

	while (
		experimental::filesystem::exists (
			name.substr(0, ext_ind) +
			postfix + to_string(ind) +
			'.' +
			name.substr(ext_ind + 1))
	) {
		++ind;
	}

	string new_name = 
		name.substr(0, ext_ind) +
		postfix + to_string(ind) +
		'.' +
		name.substr(ext_ind + 1);

	ofstream outfile(new_name);
	outfile.close();
	return (new_name);
}

//add "from" file cotent to end of "to" file
void LowLevelEditor::file_to_eof(File* from, File* to)
{
	wofstream s_to;
	wifstream s_from;

	s_from.open(from->get_file_path());
	s_to.open(to->get_file_path(), ios::app);
	s_to << endl << s_from.rdbuf();
	s_to.close();
	s_from.close();
}

//======================================<STRING_EDITOR>======================================
StringEditor::StringEditor() : LowLevelEditor() {};
StringEditor::~StringEditor()
{
	str_buf.clear();
	w_str_buf.clear();
	strings.clear();
};

//Put n str to buffer
void StringEditor::str_to_buf(File* from, size_t num)
{
	w_str_buf = L"";
	str_buf = "";

	if (from->get_encode() == "ASCII")
		str_buf = from->get_str(num);
	else
		w_str_buf = from->get_w_str(num);
}

//Put next line to buffer
void StringEditor::next_str_to_buf(File* from)
{
	w_str_buf = L"";
	str_buf = "";

	if (from->get_w_opened())
		w_str_buf = from->w_get_line();
	else
		str_buf = from->get_line();
}

//Str from buffer to eof
void StringEditor::buf_to_end_of_file(File* to)
{
	if (w_str_buf != L"")
	{
		wofstream s_to;
		s_to.open(to->get_file_path(), ios::app);
		s_to << w_str_buf << endl;
		s_to.close();
	}
	else
	{
		ofstream s_to;
		s_to.open(to->get_file_path(), ios::app);
		s_to << str_buf << endl;
		s_to.close();
	}
}

//Clean str buffer
void StringEditor::remove_strings(File* from)
{
	string to_replace = create_new("original", "buf");

	from->count_strings();
	size_t str_count = from->get_strings_count();

	from->open_file();
	if (from->get_w_opened())
	{
		wofstream w_file;
		wstring w_str;

		w_file.open(to_replace, ios::app);
		for (size_t i = 0; i < str_count; i++)
		{
			bool is_continue = false;
			w_str = from->w_get_line();
			for (size_t j = 0; j < strings.size(); j++)
				if (i == strings[j])
					is_continue = true;
			if (is_continue)
				continue;
			w_file << w_str << endl;
		}
		w_file.close();
	}
	else
	{
		ofstream file;
		string str;

		file.open(to_replace, ios::app);
		for (size_t i = 0; i < str_count; i++)
		{
			bool is_continue = false;
			str = from->get_line();
			for (size_t j = 0; j < strings.size(); j++)
				if (i == strings[j])
					is_continue = true;
			if (is_continue)
				continue;
			file << str << endl;
		}
		file.close();
	}
	from->close_file();
	from->replace_file(to_replace);
}

//Append regular expression to string in buffer
void StringEditor::replace_by_mask(File* from, string mask, string to_replace)
{
	string to_replace_f = create_new("original", "buf");

	from->count_strings();
	size_t str_count = from->get_strings_count();
	
	ofstream file;
	string str;

	from->open_file();
	file.open(to_replace_f, ios::app);
	for (size_t i = 0; i < str_count; i++)
	{
		str = from->get_line();
		str = regex_replace(str, regex(mask), to_replace);
		file << str ;
	}
	file.close();
	from->close_file();
	from->replace_file(to_replace_f);
}

//======================================<TEXT_EDITOR>======================================

TextEditor::TextEditor() : StringEditor() {}
TextEditor::~TextEditor() {}

//Count loss of ASCII convertation
size_t TextEditor::count_loss()
{
	File* o_file = get_original();
	if (o_file->get_encode() == "ASCII")
		return (0);

	wifstream s_o_file;
	wstring w_str_buf;

	size_t ret = 0;

	s_o_file.open(o_file->get_file_path());
	while (getline(s_o_file, w_str_buf))
	{
		for (size_t i = 0; i < w_str_buf.length(); i++)
		{
			int ch_buf = w_str_buf[i];
			if (ch_buf > 255)
				++ret;
		}
	}
	s_o_file.close();

	return (ret);
}

//Count strings in original file
size_t TextEditor::count_original_strings()
{
	File* o_file = get_original();
	size_t ret = 0;

	o_file->count_strings();
	ret = o_file->get_strings_count();

	original_strings = ret;
	return (ret);
}

//encapsulation of original_strings
size_t TextEditor::get_original_strings() { return (original_strings); }

//create copy of origina file
void TextEditor::dup_original()
{
	File* o_file = get_original();

	o_file->dup_file();
}

//get encode of original file
char* TextEditor::get_original_encode()
{
	File* o_file = get_original();
	string str_encode = o_file->get_encode();
	char* _encode = new char[str_encode.length() + 1];
	strcpy_s(_encode, str_encode.length() + 1, str_encode.c_str());
	return _encode;
}

//Change original file encode to ASCII
void TextEditor::to_ASCII(char to)
{
	File* o_file = get_original();

	o_file->change_encode(to);
}

//Remove duplicates from oriignal file
size_t TextEditor::remove_duplicates()
{
	File* o_file = get_original();

	size_t strings_count = count_original_strings();

	for (size_t i = 0; i < strings_count; i++)
	{
		bool is_continue = false;

		for (size_t  j = 0; j < strings.size(); ++j)
			if (i == strings[j])
				is_continue = true;
		if (is_continue)
			continue;

		str_to_buf(o_file, i);

		size_t to_add = 0;
		size_t ret = 0;
		o_file->open_file();
		do
		{
			if (w_str_buf != L"")
				ret = o_file->cmp_line(w_str_buf);
			else
				ret = o_file->cmp_line(str_buf);
			if (to_add++ <= i)
				continue;
			if (ret == 0)
				strings.push_back(to_add - 1);
		} while (ret != -1);
		o_file->close_file();
	}

	remove_strings(o_file);

	size_t ret = strings.size();
	strings.clear();

	return (ret);
}

void TextEditor::split_by_strings(size_t str_count)
{
	File* o_file = get_original();

	size_t o_str_count = count_original_strings();

	o_file->open_file();

	string to_fill_path = "";
	File* to_fill = NULL;

	size_t str_switch = 0;
	for (size_t i = 0; i < o_str_count; i++)
	{
		if (str_switch == str_count || i == 0)
		{
			if (to_fill)
				delete to_fill;
			to_fill_path = create_new(o_file->get_file_path(), "_SPLIT_BY_STR_");
			to_fill = new File(to_fill_path);
			str_switch = 0;
		}

		next_str_to_buf(o_file);
		buf_to_end_of_file(to_fill);

		++str_switch;
	}

	o_file->close_file();
}

void TextEditor::split_by_file_count(unsigned int file_count)
{
	File* o_file = get_original();

	size_t o_str_count = count_original_strings();

	size_t strs_per_file = o_str_count / file_count;
	size_t additional_strs_per_file = o_str_count % file_count;

	o_file->open_file();
	string to_fill_path = "";
	File* to_fill = NULL;

	size_t str_switch = 0;
	bool additional_switch = true;
	for (size_t i = 0; i < o_str_count; i++)
	{	
		if (str_switch == strs_per_file || i == 0)
		{
			if (to_fill)
				delete to_fill;
			to_fill_path = create_new(o_file->get_file_path(), "_SPLIT_BY_FILE_");
			to_fill = new File(to_fill_path);
			additional_switch = true;
			str_switch = 0;
		}

		next_str_to_buf(o_file);
		buf_to_end_of_file(to_fill);
		++str_switch;
		if (additional_strs_per_file > 0 && additional_switch)
		{
			additional_switch = false;
			--additional_strs_per_file;
			--str_switch;
		}
	}
	o_file->close_file();
}

void TextEditor::replace_str_by_mask(string to_change, string mask)
{
	replace_by_mask(get_original(), mask, to_change);
}

size_t TextEditor::delete_str_contains(string mask, bool contains)
{
	File* o_file = get_original();
	size_t strings_count = count_original_strings();

	string str_buf;
	o_file->open_file();
	for (size_t i = 0; i < strings_count; i++)
	{
		str_buf = o_file->get_line();
		if (regex_search(str_buf, (regex)mask))
		{
			if (contains)
				strings.push_back(i);
		}
		else
		{
			if (!contains)
				strings.push_back(i);
		}
	}
	o_file->close_file();

	remove_strings(o_file);

	size_t ret = strings.size();
	strings.clear();

	return (ret);
}

//merge auxiliary files with original file and execute options
void TextEditor::auxiliary_files_utills(bool options[3])
{
	File* o_file = get_original();
	for (size_t i = 0; i < files.size(); i++)
	{
		if (files[i]->is_original())
			continue;
		file_to_eof(files[i], o_file);
	}

	if (options[0] == 1)
		o_file->change_encode();
	if (options[1] == 1)
		remove_duplicates();
	if (options[2] == 1)
		for (size_t i = 0; i < files.size(); i++)
		{
			if (files[i]->is_original())
				continue;
			((AuxiliaryFile*)files[i])->delete_file();
			delete files[i];
			files[i] = NULL;
		}
	for (size_t i = 0; i < files.size(); i++)
	{
		if (files[i] == NULL)
			files.erase(files.begin() + i);
	}
}

//add file to files vector
void TextEditor::add_new_file(string path, bool is_original)
{
	if (is_original)
		files.push_back(new OriginalFile(path));
	else
		files.push_back(new AuxiliaryFile(path));

}

//remove file from files vector
void TextEditor::remove_file(string path)
{
	for (size_t i = 0; i < files.size(); i++)
	{
		if (files[i]->get_file_path() == path)
		{
			delete files[i];
			files.erase(files.begin() + i);
			break;
		}
	}
}