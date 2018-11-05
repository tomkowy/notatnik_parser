using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {   
        private string SaveFile()
        {            
            string fileName = "LastNote.txt";
            using (FileStream fs = File.Create(fileName))
                {
                    Byte[] note = new UTF8Encoding(true).GetBytes(Console.ReadLine());
                    fs.Write(note, 0, note.Length);
                }
            return null;
        }

        public void Run()
        {
            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij <enter> aby zapisać):");
            
            ConsoleKeyInfo forSave = Console.ReadKey();
            if (forSave.Key == ConsoleKey.Enter)
            {
                SaveFile();
            }
        }      
    }
}
