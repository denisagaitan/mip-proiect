using Proiect.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class Service
    {
        private AuthRepo AuthRepo;
        private NoteRepo NoteRepo;

        private User LoggedInUser;

        public Service(AuthRepo authRepo, NoteRepo noteRepo)
        {
            AuthRepo = authRepo;
            NoteRepo = noteRepo;
        }

        public User LogIn(String Username, String Password)
        {
            this.LoggedInUser = AuthRepo.LogIn(Username, Password);
            return LoggedInUser;
        }

        internal void AddNote(string? content)
        {
            this.NoteRepo.AddNote(new Note(content, LoggedInUser));
        }

        internal List<Note> GetNotes()
        {
            return this.NoteRepo.GetNotes();
        }

        internal IEnumerable<Note> GetNotesByUser(string? username)
        {
            List<Note> Notes = NoteRepo.GetNotes();

            IEnumerable<Note> notes =
                from note in Notes
                where note.Owner.Username == username
                select note;

            return notes;
        }
    }
}
