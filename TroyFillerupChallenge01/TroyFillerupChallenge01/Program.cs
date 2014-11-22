using System;

namespace TroyFillerupChallenge01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input {0}", args[0]);

            Console.Write("Output ");
            var sorter = new Sorter();
            var output = sorter.Sort(args[0]);
            output.ForEach(e => Console.Write("{0} ", e));
            Console.ReadLine();
        }
    }
}
