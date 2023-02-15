using Proiect.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class AuthRepo
    {
        private String FileName;

        public AuthRepo(String FileName)
        {
            this.FileName = FileName;
        }

        public User LogIn(String UserName, String Password)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\HP\Desktop\mip-proiect\Proiect\Proiect\users.in");
            foreach (string line in lines)
            {
                string[] splitLine = line.Trim().Split(";");
                if (splitLine[1] == UserName && splitLine[2] == Password)
                {
                    if (splitLine[3] == "admin")
                    {
                        return new Admin(int.Parse(splitLine[0]), splitLine[1], splitLine[2]);
                    } else
                    {
                        return new NormalUser(int.Parse(splitLine[0]), splitLine[1], splitLine[2]);
                    }
                    
                }
            }
            throw new Exception("Not found!");
        }
    }
}
