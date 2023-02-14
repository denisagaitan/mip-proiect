using Proiect.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class NoteRepo
    {
        private List<Note> Notes;
        private String FileName;

        public NoteRepo(string fileName)
        {
            Notes = new List<Note>();
            FileName = fileName;
            LoadFromFile();
        }

        private void LoadFromFile() {
            this.Notes = new List<Note>();
            string[] lines = System.IO.File.ReadAllLines(@"D:\University\Denisa\mip-proiect\Proiect\Proiect\notes.in");
            foreach (string line in lines)
            {
                string[] splitLine = line.Trim().Split(";");
                AddNote(new Note(splitLine[0], new User(0, splitLine[1], "not_needed")));
            }
        }

        private void SaveToFile()
        {
            List<String> notesToSave = new List<String>();
            foreach (Note n in Notes)
            {
                notesToSave.Add("" + n.Content + ";" + n.Owner.Username);
            }
            File.WriteAllLines(@"D:\University\Denisa\mip-proiect\Proiect\Proiect\notes.in", notesToSave);
        }

        public void AddNote(Note Note)
        {
            Notes.Add(Note);
            SaveToFile();
        }

        public List<Note> GetNotes()
        {
            return this.Notes;
        }
    }
}
