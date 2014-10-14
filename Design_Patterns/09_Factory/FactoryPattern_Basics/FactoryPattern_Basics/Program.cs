using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern_Basics
{
    class Program
    {

        interface IFruit
        {
            string FruitInfo();
        }

        class GreeceBanana : IFruit
        {
            public string FruitInfo()
            {
                return "The banana is from Greece";
            }
        }

        class BrazilBanana : IFruit
        {
            public string FruitInfo()
            {
                return "The banana is from Brazil";
            }
        }

        [Serializable]
        class ProductsFactory
        {
            //В зависимост от подадения месец на годината 
            //Factory-то създава различен банан
            public IFruit CreateFruit(int month)
            {
                if(month > 3 && month < 9)
                    return new GreeceBanana();
                if (month < 1 || month > 12)
                    throw new ArgumentException("Месецът трябва да е число между 1 и 12");
                return new BrazilBanana();
            }
        }

        static void Main(string[] args)
        {
            IFruit banana;
            ProductsFactory bananaFactory = new ProductsFactory();

            for (int i = 1; i <= 12; i++)
            {
                //Логиката за инстанциране на банана остава задължение на Factory класа
                banana = bananaFactory.CreateFruit(i);
                Console.WriteLine(banana.FruitInfo());
            }
            Console.ReadLine();
        }
    }
}
