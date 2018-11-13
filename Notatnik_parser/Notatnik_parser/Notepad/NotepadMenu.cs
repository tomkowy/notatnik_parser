using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {           
        private void SaveFile(string textNoteParameter)
        {            
            string fileName = "LastNote.txt";

            using (FileStream fs = File.Create(fileName))
                {
                    Byte[] textNote = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(textNote, 0, textNote.Length);
                }            
        }

        public void Run()
        {   
            string note;

            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");

            note = Console.ReadLine();

            ConsoleKeyInfo typedKey = Console.ReadKey();
            if (typedKey.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("To jest twoja notatka, która została zapisana do pliku txt: " + note);
                SaveFile(note);
                
                var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
                mainMenu.Run();
            }            
        }      
    }
}
