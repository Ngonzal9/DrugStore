using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Employee : Person
    {
        public string Password;
        public string User;

        public Employee()
        {
        }

        public Employee(string text1, string text2, string text3, string text4)
        {
            Name = text1;
            LastName = text2;
            User = text3;
            Password = text4;
        }
    }
}
