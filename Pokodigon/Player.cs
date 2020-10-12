using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public ArrayList pokemons { get; set; }

        public Player(int id, string name, Pokemon pokemon){
            this.id = id;
            this.name = name;
            pokemons = new ArrayList();
            pokemons.Add(pokemon);
        }

    }
}
