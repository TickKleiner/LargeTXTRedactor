#include "Caller.h"

using namespace std;

TextEditor* InitEditor()
{
	return new TextEditor();
}

int SetMainFile(TextEditor* p_EditorObject, const char* path)
{
	p_EditorObject->add_new_file(path, true);
	return (0);
}

int GetStringsCount(TextEditor* p_EditorObject)
{
	p_EditorObject->count_original_strings();
	return ((int)p_EditorObject->get_original_strings());
}

int GetEncode(TextEditor* p_EditorObject, char* encoding, int len)
{
	const char* _encoding = p_EditorObject->get_original_encode();
	bool ended = false;
	//Это на случай, если окажется, что _encoding больше encoding
	for (int i = 0; i < len; ++i)
	{
		if (ended == false && _encoding[i] == '\0')
			ended = true;
		if (ended == false)
			encoding[i] = _encoding[i];
		if (ended == true)
			encoding[i] = '\0';
	}
	return (0);
}

int CountLoss(TextEditor* p_EditorObject)
{
	int loss = (int)p_EditorObject->count_loss();
	return (loss);
}

int CreateBackup(TextEditor* p_EditorObject)
{
	p_EditorObject->dup_original();
	return (0);
}

int RemoveDuplicates(TextEditor* p_EditorObject) { return ((int)p_EditorObject->remove_duplicates()); }

int SplitByStrings(TextEditor* p_EditorObject, int stringsCount)
{
	p_EditorObject->split_by_strings(stringsCount);
	return (0);
}

int SplitByFiles(TextEditor* p_EditorObject, int filesCount)
{
	p_EditorObject->split_by_file_count(filesCount);
	return (0);
}

int FileToASCII(TextEditor* p_EditorObject, char to)
{
	if (to == 0)
		to = NULL;
	p_EditorObject->to_ASCII(to);
	return (0);
}

int ChangeByMask(TextEditor* p_EditorObject, const char* mask, const char* replacement)
{
	p_EditorObject->replace_str_by_mask(replacement, mask);
	return (0);
}

int RemoveContains(TextEditor* p_EditorObject, const char* mask, bool contains) { return ((int)p_EditorObject->delete_str_contains(mask, contains)); }

int AddAdditionalFile(TextEditor* p_EditorObject, const char* path)
{
	p_EditorObject->add_new_file(path, false);
	return (0);
}

int RemoveAdditionalFile(TextEditor* p_EditorObject, const char* path)
{
	p_EditorObject->remove_file(path);
	return (0);
}

int ExecuteAdditionalFiles(TextEditor* p_EditorObject, bool getResInASCII, bool removeDuplicates, bool removeAddFiles)
{
	bool options[3] = {
		getResInASCII,
		removeDuplicates,
		removeAddFiles
	};
	p_EditorObject->auxiliary_files_utills(options);
	return (0);
}