using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Pokemon
    {
        public string name { get; set; }
        public string type { get; set; }
        public ArrayList attacks { get; set; }
        public int health { get; set; }
        public Pokemon(string name, string type, Attack attack1, Attack attack2)
        {
            this.name = name;
            this.type = type;
            health = 150;
            attacks = new ArrayList();
            attacks.Add(attack1);
            attacks.Add(attack2);
        }
        public int damaged()
        {
            return 150 - health;
        }
        public void toDamage(int damage)
        {
            health -= damage>health?health:damage;
        }
    }
}
