using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int ex = 0x08;
            int check = 0xF0;

            Console.WriteLine((ex & check));
            MyClass my = new MyClass();
            my.Handler();
        }
    }

    public class MyClass
    {
        int num = 0;
        int numNode;
        Node prev = null;
        Node first = null;
        public delegate void HadlerCallBack();
        HadlerCallBack hc;

        public void Handler()
        {
            if(num == 0)
            {
                Console.WriteLine("Enter the number of nodes to be created: ");
                string entrace = Console.ReadLine();
                int check;
                if (String.IsNullOrEmpty(entrace) || (!String.IsNullOrEmpty(entrace) && !Int32.TryParse(entrace, out check)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number of nodes was note informed.");
                    Console.ForegroundColor = ConsoleColor.White;
                    hc = new HadlerCallBack(Handler);
                    hc();
                    return;
                }
                numNode = Int32.Parse(entrace);
            }

            if (num < numNode)
            {
                num++;
                Node next = new Node();
                next.index = num;
                if (prev != null)
                {
                    next.prev = prev;
                    prev.next = next;
                    prev = next;
                }
                else
                {
                    first = prev = next;
                }

                hc = new HadlerCallBack(Handler);
                hc();
            }
            else
            {
                Console.WriteLine("Current position: " + first.index);
                Console.WriteLine("Choose an option: ");
                Console.WriteLine(" -> To ahead");
                Console.WriteLine(" <- To back");
                Console.WriteLine(" X exit");

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (first.prev != null)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                first = first.prev;
                                Console.WriteLine("Index: " + first.index);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Error.WriteLine("You are at the first node");
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (first.next != null)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                first = first.next;
                                Console.WriteLine("Index: " + first.index);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Error.WriteLine("You are at the last node");
                            }
                            break;
                    }
                } while (keyInfo.Key != ConsoleKey.X);
            }
        }

        public static void MyFunc()
        {
            Console.WriteLine("I was called by delegate ...");
        }
    }
}
