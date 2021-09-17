using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LargeTextRedactor
{
	public class LTRDLLWrapper
	{
		private string originalFilePath;
		public string path
		{
			get { return (originalFilePath); }
			set
			{
				originalFilePath = value;
				if (value != "")
					SetMainFile(p_EditorObject, originalFilePath);
			}
		}

		private List<string> additionalFilePaths { get; set; }
		private IntPtr p_EditorObject { get; set; }

		public LTRDLLWrapper()
		{
			originalFilePath = "";
			additionalFilePaths = new List<string>();
			p_EditorObject = InitEditor();
		}

		public int addAdditionalFilePath(string path)
		{
			if (this.additionalFilePaths.Contains(path))
				return (1);
			this.additionalFilePaths.Add(path);
			AddAdditionalFile(this.p_EditorObject, path);
			return (0);
		}

		public int removeAdditionalFilePath(string path)
		{
			if (!(this.additionalFilePaths.Contains(path)))
				return (1);
			this.additionalFilePaths.Remove(path);
			RemoveAdditionalFile(this.p_EditorObject, path);
			return (0);
		}

		public string _getEncode()
		{
			StringBuilder encode = new StringBuilder(255);
			GetEncode(this.p_EditorObject, encode, encode.Capacity);
			return (encode.ToString());
		}

		public int _CountLoss() { return (CountLoss(this.p_EditorObject)); }

		public int _GetStringsCount() { return (GetStringsCount(this.p_EditorObject)); }

		public void _CreateBackup() { CreateBackup(this.p_EditorObject); }

		public void _RemoveDuplicates() { RemoveDuplicates(this.p_EditorObject); }

		public void _SplitByStrings(int stringsCount) { SplitByStrings(this.p_EditorObject, stringsCount); }

		public void _SplitByFiles(int filesCount) { SplitByFiles(this.p_EditorObject, filesCount); }

		public void _FileToASCII(char to) { FileToASCII(this.p_EditorObject, to); }

		public void _ChangeByMask(string mask, string replacement) { ChangeByMask(this.p_EditorObject, mask, replacement); }

		public void _RemoveByMask(string mask, bool contains) { RemoveContains(this.p_EditorObject, mask, contains); }

		public void _ExecuteAdditionalFiles(bool getResInASCII, bool removeDuplicates, bool removeAddFiles)
		{
			ExecuteAdditionalFiles(this.p_EditorObject, getResInASCII, removeDuplicates, removeAddFiles);
		}

		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr InitEditor();
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int SetMainFile(IntPtr p_EditorObject, string path);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int GetStringsCount(IntPtr p_EditorObject);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int GetEncode(IntPtr p_EditorObject, StringBuilder encoding, int len);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int CountLoss(IntPtr p_EditorObject);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int CreateBackup(IntPtr p_EditorObject);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int RemoveDuplicates(IntPtr p_EditorObject);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int SplitByStrings(IntPtr p_EditorObject, int stringsCount);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int SplitByFiles(IntPtr p_EditorObject, int filesCount);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int FileToASCII(IntPtr p_EditorObject, char to);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int ChangeByMask(IntPtr p_EditorObject, string mask, string replacement);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int RemoveContains(IntPtr p_EditorObject, string mask, bool contains);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int AddAdditionalFile(IntPtr p_EditorObject, string path);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int RemoveAdditionalFile(IntPtr p_EditorObject, string path);
		[DllImport("../LTRDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int ExecuteAdditionalFiles(IntPtr p_EditorObject, bool getResInASCII, bool removeDuplicates, bool removeAddFiles);
	}
}
