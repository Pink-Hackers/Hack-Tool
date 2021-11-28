using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApplication1
{
    class Program
    {
        public static bool hackFailed = false;
        public static string ip;
        static void Main(string[] args)
        {
            string name;
            string family;
            Console.WriteLine("                                               In The Name Of God              ");
            Console.Write("What's your name? ");
            name = Console.ReadLine();
            Console.Write("What's your surname? ");
            family = Console.ReadLine();
            Console.WriteLine("Welcome " + name + family + " have fun");
            //Hack
            Console.Write("Hey " + name + " plz enter IP: ");
            ip = Console.ReadLine();
            Console.WriteLine("Plz wait hacking " + ip + "...");
            progressBar();
            if (hackFailed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("Hack failed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("Hacked " + ip + " successfully!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (hackFailed == false)
            {
                GetPassword();
            }
            Console.Write("Press any to exit...");
            Console.ReadKey();
        }
        static void GetPassword()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
            Console.WriteLine("Plz type password to get information: ");
            for (int i = 3; i > 0; i--)
            {
                StringBuilder password = new StringBuilder();
                while (true)
                {
                    int x = Console.CursorLeft;
                    int y = Console.CursorTop;
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x - 1, y);
                    }
                    else if (key.Key != ConsoleKey.Backspace)
                    {
                        password.Append(key.KeyChar);
                        Console.Write("*");
                    }
                }
                if (password.ToString() == "1234")
                {
                    Console.WriteLine("");
                    Console.WriteLine(" password: 1234");
                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("password doesn't match.");
                    Console.WriteLine("Plz re-enter your password!");
                    Console.WriteLine("Attemps left: " + (i - 1));
                }
            }
        }
        static void progressBar()
        {
            float percent = 0f;
            Console.OutputEncoding = Encoding.UTF8;
            List<string> loading = new List<string>();
            for (int i = 0; i < ip.Length * 2; i++)
            {
                loading.Add("\u2591");
            }
            Console.Write(string.Join("", loading) + percent + "%");
            List<int> delays = new List<int>();
            Random rnd = new Random();
            int currentDelay = 0;
            float finalSum = 0f;
            float currentSum = 0f;
            for (int i = 0; i < loading.Count; i++)
            {
                currentDelay = rnd.Next(300, 800);
                finalSum += currentDelay;
                delays.Add(currentDelay);
            }
            for (int i = 0; i < loading.Count; i++)
            {
                if (rnd.Next(1, 100000) == 1)
                {
                    hackFailed = true;
                    break;
                }
                Thread.Sleep(delays[i]);
                loading[i] = "\u2593";
                currentSum += delays[i];
                percent = currentSum / finalSum * 100;
                Console.Write("\r");
                Console.Write(string.Join("", loading) + Convert.ToInt32(percent) + "%");
            }
        }
    }
}
