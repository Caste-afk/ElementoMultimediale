using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementoMultimediale
{
    internal class CAudio: CMultimediale, IAudio
    {
        protected int v;//volume
        protected bool inRiporduzione;

        public CAudio(string nome, int v) : base(nome)
        {
            this.v = v;
            inRiporduzione = false;
        }

        public void Play()
        {
            inRiporduzione = !inRiporduzione;
        }
        
        public void Louder()
        {

            base.IncrementaDecrementa(true, v);
        }

        public void Weaker()
        {

            base.IncrementaDecrementa(false, v);
        }

    }
}
