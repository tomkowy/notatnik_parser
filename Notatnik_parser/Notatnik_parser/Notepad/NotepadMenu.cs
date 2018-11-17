using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad {
    public class NotepadMenu {  
        
        private bool SaveFile(string textNoteParameter) {
            
            Console.WriteLine("Podaj pełną ścieżkę z nazwą pliku:");
            string pathAndFileName = Console.ReadLine();

            try {
                using (FileStream fs = File.Create(pathAndFileName)) {
                    Byte[] textNote = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(textNote, 0, textNote.Length);
                }
            }
            catch (UnauthorizedAccessException) {
                FileAttributes attr = (new FileInfo(pathAndFileName)).Attributes;
            return false;
            }            
        return true;
        }

        public void Run() {

            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");
            string note = Console.ReadLine();
            ConsoleKeyInfo typedKey = Console.ReadKey();

            if (typedKey.Key == ConsoleKey.Enter && SaveFile(note)) {                
                Console.WriteLine("Zapisano.");                                
                var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
                mainMenu.Run();
            }
            else if (typedKey.Key == ConsoleKey.Enter && !SaveFile(note)) {                
                Console.WriteLine("Błędna ścieżka. Nie udało się zapisać.");                                
            }
        }      
    }
}
