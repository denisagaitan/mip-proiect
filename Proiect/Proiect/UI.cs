using Proiect.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class UI
    {
        private Service Service;

        public UI(Service service)
        {
            this.Service = service;
        }

        private User LogIn()
        {
            Console.WriteLine("LOGIN");
            Console.WriteLine("Username: ");
            String Username = Console.ReadLine();
            Console.WriteLine("Password: ");
            String Password = Console.ReadLine();
            return Service.LogIn(Username, Password);
        }

        private void ShowMenu()
        {
            Console.WriteLine("MENIU");
            Console.WriteLine("1. Add a note");
            Console.WriteLine("2. View notes");
            Console.WriteLine("3. View notes by user");
            Console.WriteLine("X. ");
        }

        private void AddNote()
        {
            Console.WriteLine("Content: ");
            String content = Console.ReadLine();
            Service.AddNote(content);
        }
        private void ViewNotes()
        {
            Console.WriteLine("Notes: ");
            List<Note> Notes = Service.GetNotes();
            Notes.ForEach(Note =>
            {
                Console.WriteLine("Owner: " + Note.Owner.Username);
                Console.WriteLine("Content: " + Note.Content);
                Console.WriteLine();
            });
        }

        private void ViewNotesByUser()
        {
            Console.WriteLine("Username: ");
            String username = Console.ReadLine();
            IEnumerable<Note> Notes = Service.GetNotesByUser(username);
            Console.WriteLine("Owner: " + username);
            foreach (Note note in Notes) 
            {
                Console.WriteLine("Content: " + note.Content);
                Console.WriteLine();
            }
        }

        public void Start()
        {
            User u;
            while(true)
            {
                try
                {
                    u = LogIn();
                    if (u != null)
                    {
                        Console.WriteLine("Logged in as " + u.Username + ", status: ");
                    }
                    break;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Boolean isRunning = true;
            while(isRunning)
            {
                ShowMenu();
                Console.WriteLine("Your option (X to stop): ");
                String Option = Console.ReadLine();
                switch (Option)
                {
                    case "1":
                        AddNote();
                        break;
                    case "2":
                        ViewNotes();
                        break;
                    case "3":
                        ViewNotesByUser();
                        break;
                    case "X":
                        isRunning = false;
                        Console.WriteLine("BYE");
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
