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
        public int d { get; private set; }//durata
        protected bool inRiporduzione;

        public CAudio(string nome, int v, int d) : base(nome)
        {
            this.v = v;
            this.d = d;
            inRiporduzione = false;
        }

        public virtual string Play()
        {
            inRiporduzione = !inRiporduzione;
            if(inRiporduzione)
            {
                return Stampa();
            }
            return "";
        }
        
        public void Louder()
        {

            base.IncrementaDecrementa(true, v);
        }

        public void Weaker()
        {

            base.IncrementaDecrementa(false, v);
        }

        private string Stampa()
        {
            string tot="";
            for (int i =0; i < d; i++)
            {
                if (inRiporduzione)
                {
                    tot += $"{nome} " + $"{PuntiEscalamativi()}\n";
                }
            }
            return tot;
        }

        protected string PuntiEscalamativi()
        {

            string puntiEsclamativi = "";
            for (int i = 0; i < v; i++)
            {
                puntiEsclamativi += "!";
            }
            return puntiEsclamativi;
        }

        public override string ToString()
        {
            return $"Nome: {nome} | Durata: {d} | Volume:{v} | In riproduzione: {inRiporduzione}";
        }

    }
}
