using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementoMultimediale
{
    internal class CImmagine : CMultimediale, IImmagine
    {
        private int l;
        private bool mostrato;

        public CImmagine(string nome, int l) : base(nome)
        {
            this.l = l;
            mostrato = false;
        }

        public string Show()
        {
            mostrato = !mostrato;
            if(mostrato)
            {
                return Stampa();
            }
            return "";
        }

        public void Brighter()
        {
            IncrementaDecrementa(true, l);
        }

        public void Darker()
        {
            base.IncrementaDecrementa(false, l);
        }

        private string Stampa()
        {
            string asterischi = "";
            for (int i = 0; i < l; i++)
            {
                asterischi += '*';
            }
            return $"{nome} " + asterischi;
        }

        public override string ToString()
        {
            return $"Nome: {nome} | Luminosita`: {l} | mostrato: {mostrato}";
        }

    }
}
