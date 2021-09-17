#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <io.h>

using namespace std;

class __declspec(dllexport) File
{
private:
	string file_path;
	//Useless
	File();
protected:
	void fill_encode();
	string encode;
	ifstream file;
	wifstream w_file;
	bool w_opened;
	
public:
	//Useless
	bool delete_file();
	//Useless
	virtual bool change_encode(char to);
	//Useless
	virtual bool change_encode();
	//Useless
	virtual size_t get_strings_count();
	//Useless
	virtual string dup_file();
	//Useless
	virtual bool is_original();
	//Useless
	virtual void count_strings();
	//Useless
	virtual bool replace_file(string to);
	//Useless
	virtual int cmp_line(string to_cmp);
	//Useless
	virtual int cmp_line(wstring to_cmp);

	//DONE
	File(string file_path);
	//DONE
	virtual ~File();

	//DONE
	bool is_file_exist();

	//DONE
	void open_file();
	//DONE
	void close_file();
	//DONE
	bool get_w_opened();

	//DONE
	string get_file_path();

	//DONE
	string add_postfix(string postfix);

	//DONE
	string get_encode();

	//DONE
	string get_line();
	//DONE
	wstring w_get_line();

	//DONE
	//Может быть ошибка
	string get_str(size_t num);
	//DONE
	//Может быть ошибка
	wstring get_w_str(size_t num);
};

class __declspec(dllexport) OriginalFile : public File
{
private:
	size_t strings_count = 0;
	//Useless
	OriginalFile();
public:
	//DONE
	OriginalFile(string file_path);
	//DONE
	~OriginalFile();

	//DONE
	void count_strings();
	//DONE
	bool change_encode(char to);
	//DONE
	bool change_encode();
	//DONE
	size_t get_strings_count();
	//DONE
	string dup_file();
	
	//DONE
	bool replace_file(string to);

	//DONE
	int cmp_line(string to_cmp);
	//DONE
	int cmp_line(wstring to_cmp);

	//DONE
	bool is_original();
};

class __declspec(dllexport) AuxiliaryFile : public File
{
private:
	//Useless
	AuxiliaryFile();
public:
	//DONE
	AuxiliaryFile(string file_path);
	//DONE
	~AuxiliaryFile();
	//DONE
	bool delete_file();

	//DONE
	bool is_original();
};