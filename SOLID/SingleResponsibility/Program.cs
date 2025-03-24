using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibility
{
	class Journal {
		public List<string> Entries { get; } = new List<string>();

		public int AddEntry(string entry){
			Entries.Add(entry);	
			return Entries.Count;
		}

		public int RemoveEntry(int index){
			Entries.RemoveAt(index);
			return Entries.Count;
		}

		public string toString(){
			return string.Join(Environment.NewLine ,Entries);
		}
	}

	class Persistance {
		public static bool WriteTextToFile(string folderPath,string fileName, string content){
			try{
			if(!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

			File.WriteAllText(folderPath + "/" + fileName + ".txt", content);
			return true;
			}
			catch(Exception e){
				Console.WriteLine("Something went wrong when writing to file", e);
				return false;	
			}
		}

		public static string ReadFromTextFile(string path){
			try{
				return File.ReadAllText(path);
			} catch(FileNotFoundException ex) {
				Console.WriteLine("File not found", ex);
				return "";
			}
		}

	}

	class MainClass {
		static void Main(string[] args){
			Journal journal = new Journal();
			journal.AddEntry("I cried today");
			journal.AddEntry("I ate a bug");

			Persistance.WriteTextToFile("./Journal", "journal", journal.toString());

			var content = Persistance.ReadFromTextFile("./Journal/journal.txt");
			Console.WriteLine(content);
		}
	}
}
