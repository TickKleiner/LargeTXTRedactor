#pragma once
#include "TextEditor.h";
#include <iostream>

#ifdef __cplusplus
extern "C" {
#endif
	//Init main class object
	extern __declspec(dllexport) TextEditor* InitEditor();
	//Set original file
	extern __declspec(dllexport) int SetMainFile(TextEditor* p_EditorObject, const char *path);
	extern __declspec(dllexport) int GetStringsCount(TextEditor* p_EditorObject);
	extern __declspec(dllexport) int GetEncode(TextEditor* p_EditorObject, char* encoding, int len);
	//Count loss of convertation to ASCII
	extern __declspec(dllexport) int CountLoss(TextEditor* p_EditorObject);
	//Duplicate original file
	extern __declspec(dllexport) int CreateBackup(TextEditor* p_EditorObject);
	//Remove duplicate strings from original file
	extern __declspec(dllexport) int RemoveDuplicates(TextEditor* p_EditorObject);
	//Split original file to files that contains choosen amount of strings
	extern __declspec(dllexport) int SplitByStrings(TextEditor* p_EditorObject, int stringsCount);
	//Split original file to choosen amount of files
	extern __declspec(dllexport) int SplitByFiles(TextEditor* p_EditorObject, int filesCount);
	//Convert original file to ASCII encode
	extern __declspec(dllexport) int FileToASCII(TextEditor* p_EditorObject, char to);
	//Change strings that match mask to replacement
	extern __declspec(dllexport) int ChangeByMask(TextEditor* p_EditorObject, const char *mask, const char* replacement);
	//Remove string that contains or dot match mask
	extern __declspec(dllexport) int RemoveContains(TextEditor* p_EditorObject, const char* mask, bool contains);
	extern __declspec(dllexport) int AddAdditionalFile(TextEditor* p_EditorObject, const char *path);
	extern __declspec(dllexport) int RemoveAdditionalFile(TextEditor* p_EditorObject, const char* path);
	//merge additional files with original and execute some additional options if they setted
	extern __declspec(dllexport) int ExecuteAdditionalFiles(TextEditor* p_EditorObject, bool getResInASCII, bool removeDuplicates, bool removeAddFiles);
#ifdef __cplusplus
}
#endif