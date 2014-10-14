using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern_Basics
{

    //Клиент иска доставка на продукт
    //В зависимост от вида на клиента
    //се избира различен алгоритъм за доставка

    enum ClientType
    {
        PoorClient,
        RichClient,
        MostImportantClientEver
    }

    interface IDeliveryStrategy
    {
        void Deliver(ClientType type);
    }

    class DeliveryStrategy : IDeliveryStrategy
    {
        private interface IDelivery { void Deliver(); }

        private class PoorClientDelivery : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("Delivering to a fucking poor client.");
                Console.WriteLine("We will deliver the product in 5 days.");
                Console.WriteLine("And will give him the worst possible product!");
                Console.WriteLine("-------------End of delivery-------------");
            }
        }
        private class RichClientDelivery : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("Delivering to a RI$H client.");
                Console.WriteLine("We will deliver the product in ONE day.");
                Console.WriteLine("And will give him the best possible product!");
                Console.WriteLine("-------------End of delivery-------------");
            }
        }
        private class MostImportantClientDelivery : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("OMGOMOMGOMG HE'S HERE! MOSTIMPORTANT CLIENT EVAR.");
                Console.WriteLine("We will deliver the product in 0(ZERO) days.");
                Console.WriteLine("And will give him the BEST of the BEST possible product!");
                Console.WriteLine("-------------End of delivery-------------");
            }
        }

        private IDelivery Delivery { get; set; }

        public void Deliver(ClientType type)
        {
            switch (type)
            {
                case ClientType.PoorClient:
                    Delivery = new PoorClientDelivery();
                    Delivery.Deliver();
                    break;
                case ClientType.RichClient:
                    Delivery = new RichClientDelivery();
                    Delivery.Deliver();
                    break;
                case ClientType.MostImportantClientEver:
                    Delivery = new MostImportantClientDelivery();
                    Delivery.Deliver();
                    break;
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IDeliveryStrategy delivery = new DeliveryStrategy();
            delivery.Deliver(ClientType.PoorClient);
            delivery.Deliver(ClientType.RichClient);
            delivery.Deliver(ClientType.MostImportantClientEver);
            Console.ReadLine();
        }
    }
}
