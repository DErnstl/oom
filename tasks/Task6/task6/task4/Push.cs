using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using static System.Console;

namespace task6
{

    public static class PushExampleWithSubject
    {
        public static string getRandomName(int length)
        {
            char[] name = new char[length];
            Random random = new Random();
            char[] vocale = new char[] { 'a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü' };
            char c;
            for (int i = 0; i < 6; i++)
                if (i % 2 == 0)
                {
                    do c = (char)(random.Next((int)'z' - (int)'a') + (int)'a');
                    while (Array.IndexOf<char>(vocale, c) >= 0);
                    name[i] = c;
                }
                else
                    name[i] = vocale[random.Next(vocale.Length)];

            return new string(name);
        }

        public static void Run()
        {
            var source = new Subject<int>();
            Random rnd = new Random();

            source
                .Sample(TimeSpan.FromSeconds(1.0))
                .Subscribe(x => WriteLine($"received {x}"))
                ;


            var t = new Thread(() =>
            {
                var i = 0; ;// = new TransferMarket(getRandomName(5), getRandomName(8), rnd.Next(18, 45), getRandomName(8), rnd.Next(0, 100000));
                while (true)
                {
                    Thread.Sleep(250);
                    source.OnNext(i);
                    WriteLine($"sent {i}");
                    //i++;
                }
            });
            t.Start();
        }
    }
}