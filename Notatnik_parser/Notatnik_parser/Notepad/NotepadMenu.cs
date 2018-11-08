using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {           
        static void saveFile(ref string textNoteParameter)
        {            
            string fileName = "LastNote.txt";

            using (FileStream fs = File.Create(fileName))
                {
                    Byte[] note = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(note, 0, note.Length);
                }            
        }

        public void Run()
        {   
            string note;

            Console.WriteLine("Witamy w notatniku. Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");

            note = Console.ReadLine();

            ConsoleKeyInfo typedKey = Console.ReadKey();
            if (typedKey.Key == ConsoleKlaey.Enter)
            {
                Console.WriteLine("To jest twoja notatka, która została zapisana do pliku txt: " + note);
                saveFile(ref note);
            }
        }      
    }
}
