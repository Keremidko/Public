using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern_Basics
{
    public class DatabaseProxy
    {
        private class DatabaseContext
        {
            private List<object> _data;

            public DatabaseContext() { _data = new List<object>(); }

            public void addData(object obj)
            {
                _data.Add(obj);
                Console.WriteLine("Sucessfully added: "+obj);
            }

            public bool containsData(object obj)
            {
                return _data.Contains(obj);
            }
        }

        private static string password = "I AM SECRET!";
        private string userProvidedPassword { get; set; }
        private DatabaseContext db { get; set; }
        private bool Check()
        {
            if (db == null)
                db = new DatabaseContext();
            if (userProvidedPassword.Equals(password))
                return true;
            return false;
        }

        public DatabaseProxy(string password)
        {
            userProvidedPassword = password;
        }

        public void addData(object obj)
        {
            if (!Check())
            {
                Console.WriteLine("You are not correctly authenticated!");
                return;
            }
            db.addData(obj);
        }

        public bool getData(object obj)
        {
            if (!Check())
            {
                Console.WriteLine("you are not correctly authenticated!");
                return false;
            }
            return db.containsData(obj);
        }

    }

    public class runClass
    {
        static void Main(string[] args)
        {
            DatabaseProxy dbProxy = new DatabaseProxy("I AM SECRET!");
            DatabaseContext ctx = new DatabaseContext();
            dbProxy.addData(23);
            Console.ReadLine();
        }
    }
}
