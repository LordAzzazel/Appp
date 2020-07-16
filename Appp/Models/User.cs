using System;
using System.Collections.Generic;
using System.Text;

namespace Appp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(string Number, string Password)
        {
            this.Number = Number;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (!this.Number.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
