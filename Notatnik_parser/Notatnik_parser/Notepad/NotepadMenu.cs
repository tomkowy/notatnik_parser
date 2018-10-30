using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {   
        string note;

        public void SaveFile()
        {            
            string fileName = "LastNote.txt"; 
            using (System.IO.FileStream fs = System.IO.File.Create(fileName))
            {
                Byte[] toSave = new UTF8Encoding(true).GetBytes(note);
                fs.Write(toSave, 0, toSave.Length);
            }
        }

        public void Run()
        {
            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij <enter> aby zapisać):");
            note = Console.ReadLine();

            ConsoleKeyInfo saveButton = Console.ReadKey();
            if (saveButton.Key == ConsoleKey.Enter)
            {
                SaveFile();
            }
        }      
    }
}
