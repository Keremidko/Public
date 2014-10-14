using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_SelfExample
{
    interface IProduct
    {
        int Price { get; }
    }

    interface IProcessor : IProduct
    {
        string Manufacturer { get; }
        int Frequency { get;  }
    }

    interface IHDD : IProduct
    {
        string Manufacturer { get; }
        int Storage { get; }
    }

    interface IHardwareFactory
    {
        IProcessor CreateProcessor(int freq);
        IHDD CreateHDD(int storage);
    }

    class IntelProcessor : IProcessor
    {
        public IntelProcessor(int freq)
        {
            Frequency = freq;
        }

        public int Frequency { get; private set; }
        public int Price { get { return Frequency * 10; } }
        public string Manufacturer { get { return "Intel"; } }

    }

    class AMDProcessor : IProcessor
    {
        public AMDProcessor(int freq)
        {
            Frequency = freq;
        }

        public int Frequency { get; private set; }
        public int Price { get { return Frequency * 5; } }
        public string Manufacturer { get { return "AMD"; } }
    }

    class GeneralElectricHDD : IHDD
    {
        public GeneralElectricHDD(int storage)
        {
            this.Storage = storage;
        }
        public string Manufacturer { get { return "General Electric"; } }
        public int Storage { get; private set; }
        public int Price { get { return Storage * 5; } }
    }

    class AppleHDD : IHDD
    {
        public AppleHDD(int storage)
        {
            this.Storage = storage;
        }
        public string Manufacturer { get { return "Apple"; } }
        public int Storage { get; private set; }
        public int Price { get { return Storage * 10; } }
    }

    class LowClassHardwareFactory : IHardwareFactory
    {
        public LowClassHardwareFactory() { }

        public IProcessor CreateProcessor(int freq) { return new AMDProcessor(freq); }
        public IHDD CreateHDD(int storage) { return new GeneralElectricHDD(storage); }
    }

    class HighClassHardwareFactory : IHardwareFactory
    {
        public HighClassHardwareFactory() { }

        public IProcessor CreateProcessor(int freq) { return new IntelProcessor(freq); }
        public IHDD CreateHDD(int storage) { return new AppleHDD(storage); }
    }  

    class Program
    {
        public static void Consume(IHardwareFactory factory)
        {
            IHDD hdd = factory.CreateHDD(500);
            IProcessor processor = factory.CreateProcessor(2000);

            Console.WriteLine(String.Format("This HDD is from : {0}, costs : {1} euro, and has storage : {2}GB.",hdd.Manufacturer, hdd.Price, hdd.Storage));
            Console.WriteLine(String.Format("This Processor is from : {0}, costs : {1} euro, and has frequency : {2}MHz.", processor.Manufacturer, processor.Price, processor.Frequency));
        }

        static void Main(string[] args)
        {
            //Runtime мяна на използваните продукти
            Consume(new LowClassHardwareFactory());
            Console.WriteLine();
            Consume(new HighClassHardwareFactory());
            Console.ReadLine();
        }
    }
}
