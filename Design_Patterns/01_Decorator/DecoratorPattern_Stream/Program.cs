using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DecoratorPattern_Stream
{
    class Program
    {
        /*
         * Създава PasswordProtectedStraem клас който е декоратор
         * на Stream класа, и изисква правилно въведена парола при писане във stream-а
         * ако паролата не е кореткна - влиза в безкраен цикъл докато не се въведе правилна парола
         */

        class PasswordProtectedStream : Stream
        {
            private Stream _stream { get;set; }

            private string providedPassword { get; set; }

            private static string password = "THATPASSISSECRET!";

            public override bool CanSeek
            {
                get { return _stream.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return _stream.CanWrite; }
            }

            public override long Length
            {
                get { return _stream.Length; }
            }

            public override long Position
            {
                get
                {
                    return _stream.Position;
                }
                set
                {
                    _stream.Position = value;
                }
            }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (!this.providedPassword.Equals(password))
                    throw new ArgumentException("The password you provided does not match the SECRET PASSWORD!");
                return _stream.Read(buffer, offset, count);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                if (!this.providedPassword.Equals(password))
                {
                    string newPass;
                    do
                    {
                        Console.WriteLine("The password for your stream is invalid, please provide a new one!");
                        newPass = Console.ReadLine();
                    } while (!newPass.Equals(password));
                }
                _stream.Write(buffer, offset, count);
            }

            public override bool CanRead
            {
	            get { return _stream.CanRead; }
            }


            public PasswordProtectedStream(Stream stream, string pass)
            {
                this._stream = stream;
                this.providedPassword = pass;
            }
        }

        static void Main(string[] args)
        {
            PasswordProtectedStream passStream = new PasswordProtectedStream(new FileStream("C:\\Users\\Keremidko\\Desktop\\temp.txt",FileMode.OpenOrCreate), "Wrong pass!");
            byte[] buffer = new byte[5] {22, 10, 0 , 2, 4 };
            passStream.Write(buffer,0,buffer.Length);
            passStream.Close();
        }
    }
}
