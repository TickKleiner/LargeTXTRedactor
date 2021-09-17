#include "FileEditor.h"
#include <cstdio>
#include <experimental/filesystem>

using namespace std;

//Useless
File::File()
{
	file_path = "";
	encode = "";
}
//Useless
bool File::delete_file() { return (1); }
//Useless
bool File::change_encode(char to) { return (0); }
//Useless
size_t File::get_strings_count() { return (0); }
//Useless
string File::dup_file() { return (""); }
//Useless
bool File::is_original() { return (0); }
//Useless
void File::count_strings() { return; }
//Useless
bool File::replace_file(string to) { return (1); }
//Useless
int File::cmp_line(string to_cmp) { return (-1); };
//Useless
int File::cmp_line(wstring to_cmp) { return (-1); };

//DONE
File::File(string file_path)
{
	this->file_path = file_path;
	fill_encode();
}

//DONE
File::~File()
{
	file_path.clear();
	encode.clear();
}

//Определить кодировку
//DONE
void File::fill_encode()
{
    vector<unsigned char> bom(4);

    while (file.read(reinterpret_cast<char*>(bom.data()), 4))
        auto count = file.gcount();

    encode = "undefined";

    if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76)
        encode = "UTF-7";
    else if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
        encode = "UTF-8";
    else if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0)
        encode = "UTF-32LE";
    else if (bom[0] == 0xff && bom[1] == 0xfe)
        encode = "UTF-16LE";
    else if (bom[0] == 0xfe && bom[1] == 0xff)
        encode = "UTF-16BE";
    else if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff)
        encode = "UTF-32BE";
    else
        encode = "ASCII";

    bom.clear();
}

//Существует ли файл
//DONE
bool File::is_file_exist() { return(experimental::filesystem::exists(file_path)); }
//Открыть файл
//DONE
void File::open_file()
{
    if (encode == "ASCII")
    {
        file.open(file_path);
        w_opened = false;
    }
    else
    {
        w_file.open(file_path);
        w_opened = true;
    }
}
//Закрыть файл
//DONE
void File::close_file()
{
    if (w_opened)
        w_file.close();
    else
        file.close();
}
//В каком режиме открыт файл
//DONE
bool File::get_w_opened() { return (w_opened); }

//Получить путь к файлу
//DONE
string File::get_file_path() { return (file_path); }
//Добавиь постфикс к файлу
//DONE
string File::add_postfix(string postfix)
{
    size_t ext_ind = file_path.find_last_of(".");
    string new_path = 
        file_path.substr(0, ext_ind) +
        postfix +
        '.' +
        file_path.substr(ext_ind + 1);
    return (new_path);
}

//Получить кодировку файла
//DONE
string File::get_encode() { return (encode); }

bool File::change_encode() { return (false); }

//Получить след. строку
//DONE
string File::get_line()
{
    string buf;

    getline(file, buf);
    return (buf);
}
wstring File::w_get_line()
{
    wstring buf;

    getline(w_file, buf);
    return (buf);
}

//Получить строку под номером
//DONE
//Может быть ошибка
string File::get_str(size_t num)
{
    size_t ind = 0;
    string buf = "";

    open_file();
    while (ind++ <= num)
        getline(file, buf);
    close_file();
    return (buf);
}
//DONE
//Может быть ошибка
wstring File::get_w_str(size_t num)
{
    size_t ind = 0;
    wstring buf = L"";

    open_file();
    while (ind++ <= num)
        getline(w_file, buf);
    close_file();
    return (buf);
}

//================================================================================================================================================================================================================================

//Useless
OriginalFile::OriginalFile() : File("") { strings_count = 0; }

//DONE
OriginalFile::OriginalFile(string file_path) : File(file_path)
{
    count_strings();
    fill_encode();
}
//DONE
OriginalFile::~OriginalFile() {}

//Посчитать кол-во строк
//DONE
void OriginalFile::count_strings()
{
    string buf;
    wstring w_buf;

    strings_count = 0;

    open_file();
    if (w_opened)
        while (getline(w_file, w_buf))
            ++strings_count;
    else
        while (getline(file, buf))
            ++strings_count;
    close_file();
}

//Заменить кодировку на ASCII
//DONE
bool OriginalFile::change_encode(char to)
{
    if (encode == "ASCII")
        return (0);

    int ind = 1;
    while (experimental::filesystem::exists(add_postfix("_buf_" + to_string(ind))))
        ++ind;
    string dup_name = add_postfix("_buf_" + to_string(ind));

    wstring str_buf;
    string of_str;

    ofstream out_file(dup_name);
    open_file();
    while (getline(w_file, str_buf))
    {
        for (size_t i = 0; i < str_buf.length(); i++)
        {
            int ch_buf = str_buf[i];
            if (ch_buf > 255)
            {
                if (to != NULL)
                    of_str[i] = to;
                else
                    continue;
            }
            else
                of_str[i] = str_buf[i];
        }
        out_file << of_str;
    }
    close_file();
    out_file.close();

    if (replace_file(dup_name) == 1)
        return (1);

    encode = "ASCII";

    return (0);
}

bool OriginalFile::change_encode()
{
    if (encode == "ASCII")
        return (0);

    int ind = 1;
    while (experimental::filesystem::exists(add_postfix("_buf_" + to_string(ind))))
        ++ind;
    string dup_name = add_postfix("_buf_" + to_string(ind));

    wstring str_buf;
    string of_str;

    ofstream out_file(dup_name);
    open_file();
    while (getline(w_file, str_buf))
    {
        for (size_t i = 0; i < str_buf.length(); i++)
        {
            int ch_buf = str_buf[i];
            if (ch_buf > 255)
                continue;
            else
                of_str[i] = str_buf[i];
        }
        out_file << of_str;
    }
    close_file();
    out_file.close();

    if (replace_file(dup_name) == 1)
        return (1);

    encode = "ASCII";

    return (0);
}

//Создать копию файла
//DONE
string OriginalFile::dup_file()
{
    size_t ind = 1;
    while (experimental::filesystem::exists(add_postfix("_copy_" + to_string(ind))))
        ++ind;
    string dup_name = add_postfix("_copy_" + to_string(ind));

    open_file();
    if (get_w_opened())
    {
        wofstream out_file(dup_name);
        out_file << w_file.rdbuf();
        out_file.close();
    }
    else
    {
        ofstream out_file(dup_name);
        out_file << file.rdbuf();
        out_file.close();
    }
    close_file();
    return (dup_name);
}

//Заменить текущий файл новым
//DONE
bool OriginalFile::replace_file(string to)
{

    if (!experimental::filesystem::exists(to))
        return (1);

    try {
        if (!(experimental::filesystem::remove(get_file_path())))
            return (1);
    }
    catch (const experimental::filesystem::filesystem_error& err) {
        return (1);
    }
    rename(to.c_str(), get_file_path().c_str());
    count_strings();

    return (0);
}

//Сравнить след. строку с предоставленной
//DONE
int OriginalFile::cmp_line(string to_cmp)
{
    string buf;

    if (!getline(file, buf))
        return (-1);
    if (buf == to_cmp)
        return (0);
    return (1);
}
//DONE
int OriginalFile::cmp_line(wstring to_cmp)
{
    wstring w_buf;

    if (!getline(w_file, w_buf))
        return (-1);
    if (w_buf == to_cmp)
        return (0);
    return (1);
}

//Инкапсуляция strings_count
//DONE
size_t OriginalFile::get_strings_count() { return (strings_count); }
//Основной ли файл
//DONE
bool OriginalFile::is_original() { return (true); }

//================================================================================================================================================================================================================================

//Useless
AuxiliaryFile::AuxiliaryFile() : File("") {}

AuxiliaryFile::AuxiliaryFile(string file_path) : File(file_path) {}
AuxiliaryFile::~AuxiliaryFile() {}

//Удалить файл
//DONE
bool AuxiliaryFile::delete_file()
{
    try {
        if (experimental::filesystem::remove(get_file_path()))
            return (0);
        else
            return (1);
    }
    catch (const experimental::filesystem::filesystem_error& err) {
        return (1);
    }
    return (1);
}

//Основной ли файл
//DONE
bool AuxiliaryFile::is_original() { return (false); }
