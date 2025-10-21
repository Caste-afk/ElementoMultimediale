using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementoMultimediale
{
    internal class CVideo : CAudio, IAudio, ILuminosita, IComparable<CVideo>
    {
        private int l;
        private bool inRiproduzione;

        public CVideo(int v, string nome, int l, int d) : base(nome, v, d)
        {
            this.l = l;
            inRiproduzione = false;
        }

        public void Brighter()
        {
            base.IncrementaDecrementa(true, l);
        }
        public void Darker()
        {
            base.IncrementaDecrementa(false, l);
        }
        //metodi legati all'audio nella classe padre

        public override string Play()
        {
            inRiporduzione = !inRiporduzione;
            if(inRiporduzione)
            {
                return Stampa();
            }
            return "";
        }

        private string Stampa() {
            string tot="";
            
            string asterischi = "";
            for (int i = 0; i < l; i++)
            {
                asterischi += '*';
            }
            for (int i = 0; i < d; i++)
            {
                tot +=($"{nome} " + $"{base.PuntiEscalamativi()}" + asterischi);
            }
            return tot;
        }

        public override string ToString()
        {
            return $"Nome: {nome} | Durata: {d} | Volume:{v} | Luminosita`: {l} | In riproduzione: {inRiporduzione}";
        }

        public int CompareTo(CVideo other)
        {
            if (other == null) return 1;
            return this.d.CompareTo(other.d);
        }

        // Overload degli operatori di confronto
        public static bool operator >(CVideo a, CVideo b) => a.CompareTo(b) > 0;
        public static bool operator <(CVideo a, CVideo b) => a.CompareTo(b) < 0;
        public static bool operator >=(CVideo a, CVideo b) => a.CompareTo(b) >= 0;
        public static bool operator <=(CVideo a, CVideo b) => a.CompareTo(b) <= 0;

        // Overload degli operatori di uguaglianza
        public static bool operator ==(CVideo a, CVideo b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.d == b.d && a.d == b.d;
        }

        public static bool operator !=(CVideo a, CVideo b) => !(a == b);

        // Override di Equals e GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is CVideo other)
            {
                return this == other;
            }
            return false;
        }


    }
}
