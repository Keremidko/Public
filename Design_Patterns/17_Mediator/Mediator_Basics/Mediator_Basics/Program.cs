using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_Basics
{
    delegate void Callback(string message, string from);

    class Mediator
    {
        public Mediator() { }

        public void Subscribe(Callback method)
        {
            callback += method;
        }

        public void Unsubscribe(Callback method)
        {
            callback -= method;
        }

        public void Publish(string message, string from)
        {
            callback(message, from);
            Console.WriteLine();
        }

        private Callback callback;

    }

    class ChatUser
    {
        public string Name { get; set; }
        public ChatUser(string name)
        {
            this.Name = name;
        }
        public void showMessage(string message, string from)
        {
            Console.WriteLine(String.Format("User : {0} has received a message : {1} from : {2}", this.Name, message, from));
        }

        public static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            ChatUser user = new ChatUser("Petko");
            ChatUser user2 = new ChatUser("Stanko");
            ChatUser user3 = new ChatUser("STAMAT");

            mediator.Subscribe(user.showMessage);
            mediator.Subscribe(user2.showMessage);
            mediator.Subscribe(user3.showMessage);

            mediator.Publish("Fuck you bitches!", user.Name);
            mediator.Unsubscribe(user3.showMessage);
            mediator.Publish("Fu 2", user2.Name);

            Console.ReadLine();
        }
    }

}
