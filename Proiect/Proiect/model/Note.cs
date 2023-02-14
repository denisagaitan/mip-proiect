using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.model
{
    public class Note
    {
        public String Content { get; set; }    
        public User Owner { get; set; }    
        public Note(String content, User owner) 
        {
            this.Content = content;
            this.Owner = owner;
        }
    }
}
