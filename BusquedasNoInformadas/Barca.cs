using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Barca
    {
        public byte misioneros { get; set; }
        public byte canibales{ get; set; }
        public Barca(byte misioneros, byte canibales)
        {
            this.misioneros = misioneros;
            this.canibales = canibales;
        }
    }
}
