using System;
using System.Collections.Generic;
using System.Text;

namespace MuzeumApp
{
    internal class Festmeny : Mutargy
    {
        public int KorEvekben { get; set; }

        public Festmeny(string azonosito, int becsultErtek, int korEvekben): base(azonosito, becsultErtek)
        {
            KorEvekben = korEvekben;
        }

        public override int BiztositasDij()
        {
            return base.BiztositasDij() + KorEvekben * 500;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Kor: {KorEvekben} év";
        }
    }
}
