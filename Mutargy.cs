using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MuzeumApp
{
    internal class Mutargy
    {
        public string Azonosito { get; set; }

        protected int becsultErtek;

        public int BecsultErtek
        {
            get
            {
                return becsultErtek;
            }
            set
            {
                if (value <= 0)
                {
                    becsultErtek = 50000;
                }
                else
                {
                    becsultErtek = value;
                }
            }
        }

        private static int osszesMutargySzama = 0;

        public static int OsszesMutargySzama
        {
            get
            {
                return osszesMutargySzama;
            }
        }

        public Mutargy(string azonosito, int becsultErtek)
        {
            Azonosito = azonosito;
            BecsultErtek = becsultErtek;
            osszesMutargySzama++;
        }
        public virtual int BiztositasDij()
        {
            return (int)(BecsultErtek * 0.02);
        }

        public override string ToString()
        {
            return $"Műtárgy {Azonosito} | Becsült érték: {BecsultErtek} Ft | Biztosítás: {BiztositasDij()} Ft";
        }
    }
}
