using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {           
        private bool SaveFile(string textNoteParameter)
        {            
            string pathAndFileName;
            
            Console.WriteLine("Podaj pełną ścieżkę z nazwą pliku:");
            pathAndFileName = Console.ReadLine();

            try
            {
                using (FileStream fs = File.Create(pathAndFileName))
                {
                    Byte[] textNote = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(textNote, 0, textNote.Length);
                }
            }
            catch (UnauthorizedAccessException)
            {
                FileAttributes attr = (new FileInfo(pathAndFileName)).Attributes;
                Console.Write("Błędna ścieżka.");
            }
            finally
            {
                string defaultFileName = "Domyślna_notatka.txt";
                using (FileStream fs = File.Create(defaultFileName))
                {
                    Byte[] textNote = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(textNote, 0, textNote.Length);
                }
            }

            return true;
        }

        public void Run()
        {   
            string note;

            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");

            note = Console.ReadLine();

            ConsoleKeyInfo typedKey = Console.ReadKey();
            if (typedKey.Key == ConsoleKey.Enter && SaveFile(note))
            {   
                Console.WriteLine("Zapisano.");
                                
                var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
                mainMenu.Run();
            }            
        }      
    }
}
