using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transparencia.Entity
{
    class Motivos
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Motivos(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
