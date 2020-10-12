using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Attack
    {
        public string name { set; get; }
        private int _value;
        public static Random rnd = new Random();

        public Attack(string name)
        {
            this.name = name;
            this._value = rnd.Next(50) + 15; //Valor entre 15 - 65
        }

        public int attack()
        {
            return _value;
        }

    }
}
