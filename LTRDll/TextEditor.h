#pragma once

#include <iostream>
#include <string>
#include <vector>
#include "FileEditor.h"

#define MAX_STR_LEN 512

using namespace std;

class LowLevelEditor
{
protected:
	vector<File*> files;
	//DONE
	File* get_original();
	//DONE
	string create_new(string name, string postfix);
	//DONE
	void file_to_eof(File* from, File* to);
public:
	//DONE
	LowLevelEditor();
	//DONE
	virtual ~LowLevelEditor();
};

class StringEditor : public LowLevelEditor
{
protected:
	string str_buf;
	wstring w_str_buf;
	vector<size_t> strings;
	//DONE
	void str_to_buf(File* from, size_t num);
	//DONE
	void next_str_to_buf(File* from);
	//DONE
	void buf_to_end_of_file(File* to);

	//DONE
	void remove_strings(File* from);
	//DONE
	void replace_by_mask(File* from, string mask, string to_replace);
public:
	//DONE
	StringEditor();
	//DONE
	virtual ~StringEditor();
};

class TextEditor : public StringEditor
{
private:
	size_t original_strings = 0;
public:
	//DONE
	TextEditor();
	//DONE
	~TextEditor();

	//DONE
	size_t count_loss();

	//DONE
	size_t count_original_strings();

	//DONE
	size_t get_original_strings();

	//DONE
	void dup_original();

	//DONE
	char* get_original_encode();

	//DONE
	void to_ASCII(char to);

	//DONE
	size_t remove_duplicates();
	//DONE
	void split_by_strings(size_t str_count);
	//DONE
	void split_by_file_count(unsigned int file_count);
	//DONE
	void replace_str_by_mask(string to_change, string mask);
	//DONE
	size_t delete_str_contains(string mask, bool contains);
	
	//DONE
	void auxiliary_files_utills(bool options[3]);

	//DONE
	void add_new_file(string path, bool is_original);
	//DONE
	void remove_file(string path);
};