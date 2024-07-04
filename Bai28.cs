using Bai28;
using System;

namespace Bai28
{
    public class ClassDemo
    {
        public void Show()
        {
            Console.WriteLine("I am a simple class!");
        }

        public ushort InputUnsigned2ByteInteger()
        {
            ushort n = 0;
            while (true)
            {
                try
                {
                    string sz = Console.ReadLine();
                    n = ushort.Parse(sz);
                    break;
                }
                catch
                {
                    Console.Beep();
                }
            }
            return n;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ClassDemo ob = new ClassDemo();
        ob.Show();

        Console.WriteLine("Enter n:");
        ushort n = ob.InputUnsigned2ByteInteger();
        Console.WriteLine("n = " + n);
    }
}
