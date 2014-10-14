using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Basics
{

    interface IFactory<Brand>
    where Brand : IBrand
    {
        IBag CreateBag();
        IShoes CreateShoes();
        IBelt CreateBelt();
    }

    // Concrete Factories (both in the same one)
    class Factory<Brand> : IFactory<Brand>
    where Brand : IBrand, new()
    {
        public IBag CreateBag()
        {
            return new Bag<Brand>();
        }

        public IShoes CreateShoes()
        {
            return new Shoes<Brand>();

        }

        public IBelt CreateBelt()
        {
            return new Belt<Brand>();
        }
    }

    // Interface IProductA
    interface IBag
    {
        string Material { get; }
    }

    // Interface IProductB
    interface IShoes
    {
        int Price { get; }
    }

    //Interface IProductC
    interface IBelt
    {
        int Price { get; }
        string Material { get; }
    }

    class Belt<Brand> : IBelt
        where Brand : IBrand, new()
    {
        private Brand myBrand;
        public Belt()
        {
            myBrand = new Brand();
        }

        public string Material { get { return myBrand.Material; } }
        public int Price { get { return myBrand.Price; } }
    }

    // All concrete ProductA's
    class Bag<Brand> : IBag
    where Brand : IBrand, new()
    {
        private Brand myBrand;
        public Bag()
        {
            myBrand = new Brand();
        }

        public string Material { get { return myBrand.Material; } }
    }

    // All concrete ProductB's
    class Shoes<Brand> : IShoes
    where Brand : IBrand, new()
    {
        private Brand myBrand;
        public Shoes()
        {
            myBrand = new Brand();
        }

        public int Price { get { return myBrand.Price; } }
    }

    // An interface for all Brands
    interface IBrand
    {
        int Price { get; }
        string Material { get; }
    }

    class Gucci : IBrand
    {
        public int Price { get { return 1000; } }
        public string Material { get { return "Crocodile skin"; } }
    }

    class Poochy : IBrand
    {
        public int Price { get { return new Gucci().Price / 3; } }
        public string Material { get { return "Plastic"; } }
    }

    class Groundcover : IBrand
    {
        public int Price { get { return 2000; } }
        public string Material { get { return "South african leather"; } }
    }

    class Client<Brand>
   where Brand : IBrand, new()
    {
        public void ClientMain()
        {
            IFactory<Brand> factory = new Factory<Brand>();

            IBag bag = factory.CreateBag();
            IShoes shoes = factory.CreateShoes();
            IBelt belt = factory.CreateBelt();

            Console.WriteLine("I bought a Bag which is made from " + bag.Material);
            Console.WriteLine("I bought some shoes which cost " + shoes.Price);
            Console.WriteLine("The belt is from material " + belt.Material + " and costs " + belt.Price);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client<Gucci>().ClientMain();
            new Client<Poochy>().ClientMain();
            new Client<Groundcover>().ClientMain();
            Console.ReadLine();
        }
    }
}
