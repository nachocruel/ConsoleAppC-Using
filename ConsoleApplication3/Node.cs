using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Node
    {
        public int index { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }
        public void printMessage()
        {
            Console.WriteLine("Node: " + index);
        }
    }
}
