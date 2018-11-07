using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {   
        string noteText;

        private string GetText()
        {
            noteText = Console.ReadLine();
            return noteText;
        }
        
        private string SaveFile(string noteText)
        {            
            string fileName = "LastNote.txt";
            using (FileStream fs = File.Create(fileName))
                {
                    Byte[] note = new UTF8Encoding(true).GetBytes(noteText);
                    fs.Write(note, 0, note.Length);
                }
            return null;
        }

        public void Run()
        {
            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij <enter> aby zapisać):");
            
            GetText();

            ConsoleKeyInfo typedKey = Console.ReadKey();
            if (typedKey.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("To jest twoja notatka, która została zapisana do pliku txt: " + noteText);
                SaveFile(noteText);
            }
        }      
    }
}
