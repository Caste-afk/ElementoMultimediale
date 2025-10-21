using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementoMultimediale
{
    internal class CVideo : CAudio, IAudio, IImmagine
    {
        private int d;//durata
        private int l;

        public CVideo(int v, string nome, int l, int d) : base(nome, v)
        {
            this.l = l;
            this.d = d;
        }

        
    }
}
