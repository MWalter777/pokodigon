using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Program
    {
        private static Player player;
        private static ArrayList pokemons = new ArrayList();

        static void Main(string[] args)
        {
            int exit = 0;
            Console.Clear();
            Console.WriteLine("Como te llamas?");
            string name = Console.ReadLine();
            Console.Clear();
            createPokemons();
            Pokemon pokemon = getPokemon();
            player = new Player(0, name, pokemon);

            while (exit != 1 && pokemons.Count > 0){
                startGame(name);
                exit = askForContinue();
                if (exit == 0)
                {
                    foreach(Pokemon p in player.pokemons)
                    {
                        p.health = 150;
                    }

                    foreach (Pokemon p in pokemons)
                    {
                        p.health = 150;
                    }
                }
            }

            
            Console.Clear();
            Console.WriteLine("             ____  ____  _  __ ____  ____  _  _____ ____  _     ");
            Console.WriteLine("            /  __\\/  _ \\/ |/ //  _ \\/  _ \\/ \\/  __//  _ \\/ \\  /|");
            Console.WriteLine("            |  \\/|| / \\||   / | / \\|| | \\|| || |  _| / \\|| |\\ ||");
            Console.WriteLine("            |  __/| \\_/||   \\ | \\_/|| |_/|| || |_//| \\_/|| | \\||");
            Console.WriteLine("            \\_/   \\____/\\_|\\_\\____/\\____/\\_/\\____\\____/\\_/  \\|");
            Console.WriteLine("");
            Console.WriteLine("*******************FELICIDADES {0}, ESTOS SON TUS POKEMONES**********************", player.name);
            foreach (Pokemon p in player.pokemons)
            {
                Console.WriteLine(p.name);
            }
            Console.ReadLine();
        }

        private static void startGame(string name)
        {
            Pokemon pokemon = (Pokemon)player.pokemons.ToArray()[0];
            while (pokemon.health>0 && pokemons.Count>0)
            {
                Pokemon pokemon2 = getPokemon();
                int turno = 0;
                while (pokemon2!=null && pokemon2.health > 0 && pokemon.health > 1){
                    turno = Attack.rnd.Next(100) > 50 ? 1 : 0;
                    ArrayList itemy = new ArrayList();
                    itemy.Add("");
                    ArrayList itemy2 = new ArrayList();
                    foreach (Attack a in pokemon.attacks)
                    {
                        itemy2.Add(a.name);
                    }
                    itemy2.Add("Cambiar");
                    ArrayList itemy3 = new ArrayList();
                    itemy3.Add("Vida: " + pokemon2.health);
                    foreach (Attack a in pokemon2.attacks)
                    {
                        itemy3.Add(String.Format("{0}: {1}", a.name, a.attack()));
                    }
                    itemy3.Add("Nombre: " + pokemon2.name);

                    ArrayList itemy4 = new ArrayList();
                    itemy4.Add("Vida: " + pokemon.health);
                    foreach (Attack a in pokemon.attacks)
                    {
                        itemy4.Add(String.Format("{0}: {1}", a.name, a.attack()));
                    }
                    itemy4.Add("Nombre: " + pokemon.name);

                    Menu menu = new Menu(itemy, itemy3, itemy4, itemy2);
                    menu.printAll(5);
                    Attack atack2 = (Attack)pokemon2.attacks.ToArray()[turno];
                    pokemon.toDamage(Attack.rnd.Next(atack2.attack() - 15) + 15);

                    if (turno == 1)
                    {
                        Console.SetCursorPosition(10, 18);
                        Console.Write("Turno del oponente");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(".");
                            Thread.Sleep(500);
                        }
                        itemy4 = new ArrayList();
                        itemy4.Add("Vida: " + pokemon.health);
                        foreach (Attack a in pokemon.attacks)
                        {
                            itemy4.Add(String.Format("{0}: {1}", a.name, a.attack()));
                        }
                        itemy4.Add("Nombre: " + pokemon.name);
                        menu = new Menu(itemy, itemy3, itemy4, itemy2);
                        menu.printAll(5);
                    }

                    int v2 = menu.getOptionXDown();
                    if (v2 >= 2 && player.pokemons.Count>0)
                    {
                        itemy = new ArrayList();
                        foreach (Pokemon p in player.pokemons)
                        {
                            itemy.Add(p.name);
                        }
                        menu = new Menu(itemy, itemy3, itemy4, itemy2);
                        menu.printItemsY();
                        int option = menu.getOptionY();
                        pokemon = (Pokemon)player.pokemons.ToArray()[option];
                    }
                    else
                    {
                        Attack atack0 = (Attack)pokemon.attacks.ToArray()[v2];
                        int value = 0;
                        String v;
                        Console.SetCursorPosition(0, 27);
                        do
                        {
                            Console.WriteLine("Digite el valor del ataque, entre 15 y {0} puntos", atack0.attack());
                            v = Console.ReadLine();
                            try
                            {
                                value = int.Parse(v);
                            }
                            catch (Exception e) { }
                        } while (v == null || value < 15 || value > atack0.attack() || v == "");
                        pokemon2.toDamage(value);
                    }
                }

                if(pokemon2 != null)
                {
                    pokemon2.health = 150;
                    if (Attack.rnd.Next(100) > 50 && pokemon.health > 1)
                    {
                        player.pokemons.Add(pokemon2);
                    }
                    else
                    {
                        pokemons.Add(pokemon2);
                    }

                }
            }


        }

        private static Pokemon getPokemon()
        {
            if (pokemons.Count > 0)
            {
                int len = pokemons.Count - 1;
                int p = Attack.rnd.Next(len);
                Object[] res = pokemons.ToArray();
                pokemons.RemoveAt(len);
                return (Pokemon)res[len];
            }else
            {
                return null;
            }
        }

        private static void createPokemons(){
            string[] names = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Pikachuu" };
            string[] types = { "Agua", "Volador", "Volador", "Fuego", "Agua", "Fuego", "Electricidad", "Electricidad" };
            string[] attacs = { "Atq. agua 1", "atq. aereo 1", "atq. aereo 2", "atq. fuego 1", "atq. agua 2", "atq. fuego 2", "atq. electrico 1", "atq. electrico 1","Atq. agua 3", "atq. aereo 3", "atq. aereo 4", "atq. fuego 3", "atq. agua 4", "atq. fuego 4", "atq. electrico 3", "atq. electrico 3" };
            for(int i=0; i < names.Length; i++)
            {
                pokemons.Add(new Pokemon(names[i], types[i], new Attack(attacs[i]), new Attack(attacs[i+8])));
            }
        }

        private static int askForContinue()
        {
            System.Console.Clear();
            int res = 0;
            Console.WriteLine("DESEA CONTINUAR?");
            System.Console.SetCursorPosition(10, 4);
            Console.Write(" ______");
            System.Console.SetCursorPosition(10, 5);
            Console.Write("|  SI  |");
            System.Console.SetCursorPosition(10, 6);
            Console.Write(" ¯¯¯¯¯¯ ");
            System.Console.SetCursorPosition(25, 4);
            Console.Write("        ");
            System.Console.SetCursorPosition(25, 5);
            Console.Write("   NO   ");
            System.Console.SetCursorPosition(25, 6);
            Console.Write("        ");
            var c = Console.ReadKey().Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.LeftArrow:
                        System.Console.SetCursorPosition(10, 4);
                        Console.Write(" ______");
                        System.Console.SetCursorPosition(10, 5);
                        Console.Write("|  SI  |");
                        System.Console.SetCursorPosition(10, 6);
                        Console.Write(" ¯¯¯¯¯¯ ");
                        System.Console.SetCursorPosition(25, 4);
                        Console.Write("        ");
                        System.Console.SetCursorPosition(25, 5);
                        Console.Write("   NO   ");
                        System.Console.SetCursorPosition(25, 6);
                        Console.Write("        ");
                        res = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        System.Console.SetCursorPosition(10, 4);
                        Console.Write("        ");
                        System.Console.SetCursorPosition(10, 5);
                        Console.Write("   SI   ");
                        System.Console.SetCursorPosition(10, 6);
                        Console.Write("        ");
                        System.Console.SetCursorPosition(25, 4);
                        Console.Write(" ______ ");
                        System.Console.SetCursorPosition(25, 5);
                        Console.Write("|  NO  |");
                        System.Console.SetCursorPosition(25, 6);
                        Console.Write(" ¯¯¯¯¯¯ ");
                        res = 1;
                        break;
                }
                c = Console.ReadKey().Key;
            }
            return res;
        }

    }
}
