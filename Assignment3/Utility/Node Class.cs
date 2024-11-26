using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Node
    {
        public string Value { get; set; } // data part
        public Node Next { get; set; } // link or connection part

        public Node(string value) //constructor of MyNode
        {
            Value = value;
            Next = null;
        }

    }
}
