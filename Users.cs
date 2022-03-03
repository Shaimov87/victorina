using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace victorina
{
    class Users
    {
        public string login { get; set; }
        public string pasword { get; set; }
        public override string ToString()
        {
            return $"{login}:{pasword}\n";
        }

        public Users (string login,string pasword)
        {
            this.login = login;
            this.pasword = pasword;
            File.AppendAllText("users.dat", this.ToString());
        }
    }
}
