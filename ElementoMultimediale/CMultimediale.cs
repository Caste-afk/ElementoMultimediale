using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementoMultimediale
{
    internal abstract class CMultimediale
    {
        //IMPELEMENTARE ALTRE DUE INTERFACCE. IVOLUME E ILUMINOSITA
        protected string nome;

        protected CMultimediale(string nome)
        {
            this.nome = nome;
        }
        protected void IncrementaDecrementa(bool pos, int value)
        {

            if (value <= 100)
            {
                if (pos)
                {
                    value += 5;
                }
                else
                {
                    value -= 5;
                }
            }
        }

    }
}
