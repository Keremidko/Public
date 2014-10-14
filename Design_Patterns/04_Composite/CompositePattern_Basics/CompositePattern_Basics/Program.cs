using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern_Basics
{

    //A manager is an employee who leads engineers, technicians, and support personnel,
    //all of whom are also employees. Focusing on the operation of going on
    //leave, model this scenario with the Composite pattern.

    //Операции които може да прави всеки работник
    interface IEmployee
    {
        //Заваряване
        void StartWelding();
    }

    class Employee : IEmployee
    {
        public string Name { get; set; }

        public Employee(string Name)
        {
            this.Name = Name;
        }

        public void StartWelding()
        {
            Console.WriteLine(this.Name + " started welding!");
        }
    }

    class Manager : IEmployee
    {
        private List<IEmployee> servants { get; set; }

        public string Name { get; set; }

        public Manager(string Name)
        {
            this.Name = Name;
            this.servants = new List<IEmployee>();
        }

        public void AddServant(IEmployee servant)
        {
            servants.Add(servant);
        }

        public void RemoveServant(IEmployee servant)
        {
            servants.Remove(servant);
        }

        public void StartWelding()
        {
            StartWelding(1);
        }

        private void StartWelding(int depth)
        {
            Console.WriteLine(this.Name + " нареди на бачкаторите си да заваряват!");

            string spacing = "";
            for (int i = 0; i < depth-1; i++)
                spacing += "\t";

            Console.WriteLine(spacing + "-----------------------------");
            foreach (IEmployee servant in servants)
            {
                Console.Write(spacing + "\t");
                if (servant is Manager)
                    (servant as Manager).StartWelding(depth + 1);
                else
                    servant.StartWelding();
            }
            Console.WriteLine(spacing + "-----------------------------");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IEmployee firstEmpl = new Employee("Pesho");
            IEmployee secondEmpl = new Employee("Gosho");
            IEmployee thirdEmpl = new Employee("Toshko");
            IEmployee fourthEmpl = new Employee("Mariika");

            IEmployee firstManager = new Manager("Васко - младия меринджей ");
            IEmployee secondManager = new Manager("Спаско - баш шефа!");
            IEmployee thirdManager = new Manager("Почдчинен на Васко");

            (firstManager as Manager).AddServant(firstEmpl);
            (firstManager as Manager).AddServant(secondEmpl);
            (firstManager as Manager).AddServant(thirdManager);

            (secondManager as Manager).AddServant(firstManager);
            (secondManager as Manager).AddServant(thirdEmpl);

            (thirdManager as Manager).AddServant(fourthEmpl);

            secondManager.StartWelding();

            secondEmpl.StartWelding();
            firstEmpl.StartWelding();

            Console.ReadLine();
        }
    }
}
