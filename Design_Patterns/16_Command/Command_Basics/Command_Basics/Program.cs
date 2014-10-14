using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Command_Basics
{
    delegate void Invoker();

    static class InvokerExtensions
    {
        static int count;
        public static int Count(this Invoker invoker)
        {
            return count;
        }
        public static void Log(this Invoker invoker)
        {
            count++;
        }
    }

    class CommandMenu
    {
        abstract class ICommand
        {
            public Invoker Execute, Redo, Undo;
        }
        // Command 1
        class Paste : ICommand
        {
            public Paste(Document document)
            {
                Execute = delegate { Execute.Log(); document.Paste(); };
                Redo = delegate { Redo.Log(); document.Paste(); };
                Undo = delegate { Undo.Log(); document.Restore(); };
            }
        }
        // Command 2 - without an Undo method
        class Print : ICommand
        {
            public Print(Document document)
            {
                Execute = delegate { Redo.Log(); document.Print(); };
                Redo = delegate { Redo.Log(); document.Print(); };
                Undo = delegate { Redo.Log(); Console.WriteLine("Cannot undo a Print "); };
            }
        }
        // Common state
        static string clipboard;
        // Receiver
        class Document
        {
            string name;
            string oldpage, page;
            public Document(string name)
            {
                this.name = name;
            }
            public void Paste()
            {
                oldpage = page;
                page += clipboard + "\n";
            }
            public void Restore()
            {
                page = oldpage;
            }
            public void Print()
            {
                Console.WriteLine(
                "File " + name + " at " + DateTime.Now + "\n" + page);
            }
        }

        static void Main(string[] args)
        {
            Document doc = new Document("Custom document");
            Paste paste = new Paste(doc);
            Print print = new Print(doc);

            clipboard = "Hello to all!";

            paste.Execute();
            print.Execute();
            paste.Undo();
            print.Undo();

            clipboard = "Bonjour, mes amis";

            paste.Execute();
            clipboard = "Guten morgen, meine Freunde";
            paste.Redo();
            print.Execute();
            print.Undo();

            Console.ReadLine();
        }
    }
}
