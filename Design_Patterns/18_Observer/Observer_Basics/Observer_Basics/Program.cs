using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Basics
{
    class Program
    {

        delegate void SubscriptionCallback(string msg, string post);

        class Blog
        {
            public Blog(string n)
            {
                Name = n;
                Messages = new List<string>();
            }
            public List<string> Messages { get; set; }
            public string Name { get; set; }
            private SubscriptionCallback subscribers;
            public void Subscribe(Subscriber s)
            {
                subscribers += s.ShowNewPost;
            }
            public void Unsubscribe(Subscriber s)
            {
                subscribers -= s.ShowNewPost;
            }

            private void NotifySubscribers(string msg)
            {
                subscribers(msg, Name);
            }
            public void PostMessage(string msg)
            {
                Messages.Add(msg);
                NotifySubscribers(msg);
            }
        }

        class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(Blog b, string n)
            {
                Name = n;
                b.Subscribe(this);
            }
            public void ShowNewPost(string post, string postName)
            {
                Console.WriteLine("<!------------Subscriber " + Name + " was notified!------------!>");
                Console.WriteLine("The blog "+postName+"has published the following message :"+
                    "\n" + post);
            }
        }

        static void Main(string[] args)
        {
            Blog aspBlog = new Blog("ASP.NET Blog!");
            Blog phpBlog = new Blog("PHP Blog!");

            Subscriber aspFan = new Subscriber(aspBlog, "Petko fena");
            Subscriber phpFan = new Subscriber(phpBlog, "Goshko");
            Subscriber webDev = new Subscriber(aspBlog, "Guru");

            phpBlog.Subscribe(webDev);

            aspBlog.PostMessage("ASP.Net is great !!");
            Console.WriteLine();
            phpBlog.PostMessage("PHP is better.... NOT!");
            Console.WriteLine();

            phpBlog.Unsubscribe(phpFan);
            phpBlog.PostMessage("Only gurus stay and study php!");

            Console.ReadLine();
        }
    }
}
