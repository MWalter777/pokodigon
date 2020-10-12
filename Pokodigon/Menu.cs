using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Menu
    {
        public int x { get; set; }
        public int y { get; set; }
        public ArrayList itemsY { set; get; }
        public ArrayList itemsXUPLeft { set; get; }
        public ArrayList itemsXUPRigth { set; get; }
        public ArrayList itemsXDOWN { set; get; }

        public Menu(ArrayList itemsY, ArrayList itemsXUPLeft, ArrayList itemsXUPRigth, ArrayList itemsXDOWN)
        {
            this.itemsY = itemsY;
            this.itemsXUPLeft = itemsXUPLeft;
            this.itemsXUPRigth = itemsXUPRigth;
            this.itemsXDOWN = itemsXDOWN;
            this.x = 0;
            this.y = 0;
        }

        public Menu(ArrayList itemsY, ArrayList itemsXUPLeft, ArrayList itemsXUPRigth , ArrayList itemsXDOWN, int x, int y) : this(itemsY, itemsXUPLeft, itemsXUPRigth, itemsXDOWN)
        {
            this.x = x;
            this.y = y;
        }

        public void printItemsY()
        {
            System.Console.Clear();
            int aux = y;
            foreach (string val in itemsY)
            {
                Console.SetCursorPosition(x + 4, aux);
                Console.WriteLine(val);
                aux ++;
            }
        }

        public void printItemsXDown()
        {
            int valY = 20;
            int aux = x+20;
            foreach (string val in itemsXDOWN)
            {
                Console.SetCursorPosition(aux+4, valY);
                Console.WriteLine(val);
                aux += 20;
             }
        }

        public void printItemsX(int start)
        {
            int aux = start;
            foreach (string val in itemsXUPLeft)
            {
                Console.SetCursorPosition(10, start);
                Console.Write(val);
                start++;
            }
            start = aux;
            foreach (string val in itemsXUPRigth)
            {
                Console.SetCursorPosition(70, start);
                Console.Write(val);
                start++;
            }
        }

        public void printAll(int start)
        {
            printItemsY();
            Console.SetCursorPosition(0,0);
            Console.Write("                  ____  ____  _  __ ____  ____  _  _____ ____  _     ");
            Console.SetCursorPosition(0, 1);
            Console.Write("                 /  __\\/  _ \\/ |/ //  _ \\/  _ \\/ \\/  __//  _ \\/ \\  /|");
            Console.SetCursorPosition(0, 2);
            Console.Write("                 |  \\/|| / \\||   / | / \\|| | \\|| || |  _| / \\|| |\\ ||");
            Console.SetCursorPosition(0, 3);
            Console.Write("                 |  __/| \\_/||   \\ | \\_/|| |_/|| || |_//| \\_/|| | \\||");
            Console.SetCursorPosition(0, 4);
            Console.Write("                 \\_/   \\____/\\_|\\_\\____/\\____/\\_/\\____\\____/\\_/  \\|");
            printItemsXDown();
            printItemsX(start);
        }

        public int getOptionY()
        {
            int res = y;
            int length = itemsY.Count - 1;
            System.Console.SetCursorPosition(0, res);
            Console.Write(">>>");
            System.Console.SetCursorPosition(21, res);
            Console.Write("<<<");
            var c = Console.ReadKey().Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        System.Console.SetCursorPosition(0, res);
                        Console.Write("   ");
                        System.Console.SetCursorPosition(21, res);
                        Console.Write("   ");
                        if (res > 0) res--;
                        else res = length;
                        System.Console.SetCursorPosition(0, res);
                        Console.Write(">>>");
                        System.Console.SetCursorPosition(21, res);
                        Console.Write("<<<");
                        break;
                    case ConsoleKey.DownArrow:
                        System.Console.SetCursorPosition(0, res);
                        Console.Write("   ");
                        System.Console.SetCursorPosition(21, res);
                        Console.Write("   ");
                        if (res < length) res++;
                        else res = 0;
                        System.Console.SetCursorPosition(0, res);
                        Console.Write(">>>");
                        System.Console.SetCursorPosition(21, res);
                        Console.Write("<<<");
                        break;
                }
                c = Console.ReadKey().Key;
            }
            System.Console.SetCursorPosition(0, res);
            Console.Write("   ");
            System.Console.SetCursorPosition(21, res);
            Console.Write("   ");
            return res;
        }


        public int getOptionXDown()
        {
            int res = 0, valY = 20;
            int aux = x + 20;
            int length = itemsXDOWN.Count - 1;

            System.Console.SetCursorPosition(aux + 4, valY - 1);
            Console.Write("________________");
            System.Console.SetCursorPosition(aux + 4, valY + 1);
            Console.Write("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            System.Console.SetCursorPosition(aux + 3, valY);
            Console.Write("|");
            System.Console.SetCursorPosition(aux + 20, valY);
            Console.Write("|");

            var c = Console.ReadKey(true).Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.LeftArrow:
                        System.Console.SetCursorPosition(aux + 4, valY - 1);
                        Console.Write("                ");
                        System.Console.SetCursorPosition(aux + 4, valY + 1);
                        Console.Write("                ");
                        System.Console.SetCursorPosition(aux + 3, valY);
                        Console.Write(" ");
                        System.Console.SetCursorPosition(aux + 20, valY);
                        Console.Write(" ");
                        if (res>0)
                        {
                            aux -= 20;
                            res--;
                        }
                        else
                        {
                            aux = length*20+20;
                            res = length;
                        }
                        System.Console.SetCursorPosition(aux + 4, valY - 1);
                        Console.Write("________________");
                        System.Console.SetCursorPosition(aux + 4, valY + 1);
                        Console.Write("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                        System.Console.SetCursorPosition(aux + 3, valY);
                        Console.Write("|");
                        System.Console.SetCursorPosition(aux + 20, valY);
                        Console.Write("|");
                        break;
                    case ConsoleKey.RightArrow:
                        System.Console.SetCursorPosition(aux + 4, valY - 1);
                        Console.Write("                ");
                        System.Console.SetCursorPosition(aux + 4, valY + 1);
                        Console.Write("                ");
                        System.Console.SetCursorPosition(aux + 3, valY);
                        Console.Write(" ");
                        System.Console.SetCursorPosition(aux + 20, valY);
                        Console.Write(" ");
                        if (res < length)
                        {
                            aux += 20;
                            res++;
                        }
                        else
                        {
                            aux = x + 20;
                            res = 0;
                        }
                        System.Console.SetCursorPosition(aux + 4, valY - 1);
                        Console.Write("________________");
                        System.Console.SetCursorPosition(aux + 4, valY + 1);
                        Console.Write("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                        System.Console.SetCursorPosition(aux + 3, valY);
                        Console.Write("|");
                        System.Console.SetCursorPosition(aux + 20, valY);
                        Console.Write("|");
                        break;
                }
                c = Console.ReadKey(true).Key;
            }
            return res;
        }


    }
}
