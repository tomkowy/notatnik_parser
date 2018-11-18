using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {    
        string pathInstructions = "Podaj pełną ścieżkę z nazwą pliku lub samą nazwę pliku z rozszerzeniem, żeby {0} domyślnego folderu:";
        
        public void Run() {

            ShowNotpadMenu();
            MenageUserInput();
        }

        public void ShowNotpadMenu()
        {
            Console.WriteLine("Witamy w notatniku. Wybierz:");
            Console.WriteLine("1 - nowa notatka");
            Console.WriteLine("2 - otwórz notatkę");
        }

        private void MenageUserInput()
        {
            string insertValue;
            do
            {
                insertValue = Console.ReadLine();

            } while (!IsUserInputValid(insertValue));

            GoToUserChoice(insertValue);
        }

        private bool IsUserInputValid(string userInput)
        {
            if (userInput == "1" || userInput == "2")
            {
                return true;
            }

            Console.WriteLine("Proszę wybrać numer z listy");
            return false;
        }

        private void GoToUserChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    WriteNewNote();
                    break;
                case "2":
                    MenageUserPathInput();
                    break;
                default:
                    Console.WriteLine("Błąd");
                    break;
            }
        }

        private void WriteNewNote()
        {       
            Console.WriteLine("Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");
            string note = Console.ReadLine();
            ConsoleKeyInfo typedKey = Console.ReadKey();

            if (typedKey.Key == ConsoleKey.Enter && SaveFile(note))
            {                
                Console.WriteLine("Zapisano.");                                
                var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
                mainMenu.Run();
            }
            else if (typedKey.Key == ConsoleKey.Enter && !SaveFile(note))
            {                
                Console.WriteLine("Błędna ścieżka. Nie udało się zapisać.");                                
            }
        }

        private bool SaveFile(string textNoteParameter)
        {    
            Console.WriteLine(pathInstructions, "zapisać do");
            string pathAndFileName = Console.ReadLine();

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
                return false;
            }
            
            return true;
        }

        private void OpenTextFile(string insertPathValue)
        {
            using (FileStream fs = File.Open(insertPathValue, FileMode.Open)) 
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b,0,b.Length) > 0) 
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

        private bool IsUserPathInputValid(string insertPathValue)
        {
            if(File.Exists(insertPathValue)) 
            {
                OpenTextFile(insertPathValue);
                return true;
            }               
            else 
            {
                Console.WriteLine("{0} - ta ścieżka jest niewłaściwa.", insertPathValue);
                return false;
            }      
        }
        
        private void MenageUserPathInput()
        {
            string insertPathValue;
            do
            {   
                Console.WriteLine(pathInstructions, "otworzyć z");                
                insertPathValue = Console.ReadLine();
            }
            while (!IsUserPathInputValid(insertPathValue));

            var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
            mainMenu.Run();
        }
    }
}
