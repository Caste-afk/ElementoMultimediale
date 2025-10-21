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

        public void Show()
        {
            mostrato = !mostrato;
        }

        public void Brighter()
        {
        }

        public void Darker()
        {
            base.IncrementaDecrementa(false, l);
        }

        

    }
}
