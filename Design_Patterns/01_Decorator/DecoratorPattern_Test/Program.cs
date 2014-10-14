using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern_Test
{
    class Program
    {

        interface IApple
        {
            int size { get; set; }
            string color { get; set; }
        }

        //Някъв вид руска ябълка : D
        class Antonovka : IApple
        {
            private string _color;
            private int _size;

            public int size
            {
                get
                {
                    return _size;
                }
                set
                {
                    _size = value;
                }
            }

            public string color {
                set
                {
                    _color = value;
                }
                get
                {
                    return _color;
                }
            }

            public override string ToString()
            {
                return "Color : " + _color + " size : " + _size;
            }

            public Antonovka(int size, string color)
            {
                _size = size;
                _color = color;
            }
        }

        class AntonovkaDecorator : IApple
        {
            private IApple _apple;

            public AntonovkaDecorator(IApple apple)
            {
                this._apple = apple;
            }

            public int size
            {
                get
                {
                    return _apple.size + 5;
                }
                set
                {
                    _apple.size = value;
                }
            }

            public string color
            {
                get
                {
                    return _apple.color + " plus it has dots on it!";
                }
                set
                {
                    _apple.color = value;
                }
            }

            public override string ToString()
            {
                return "Color : " + color + " size : " + size;
            }
        }

        static void Main(string[] args)
        {
            IApple firstApple = new Antonovka(25, "Black");
            IApple decoratedApple = new AntonovkaDecorator(firstApple);

            Console.WriteLine(firstApple);
            Console.WriteLine(decoratedApple);
            Console.ReadLine();
        }
    }
}
