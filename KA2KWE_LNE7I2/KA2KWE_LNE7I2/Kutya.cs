using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA2KWE_LNE7I2
{
   public class Kutya
    {
        private readonly int _kor;
        private readonly string _nev;
        private readonly bool _ehes;

        public Kutya(int kor, string nev, bool ehes)
        {
            _kor = kor;
            _nev = nev;
            _ehes = ehes;

        }
        public int Kor { get { return _kor; } }
        public string Nev { get { return _nev; } }

        public bool Ehes { get { return _ehes; } }

        public Kutya Etet() { return new Kutya(_kor, _nev, false); }
        public Kutya Megehez() { return new Kutya(_kor, _nev, true); }
        public Kutya Oregedes() { return new Kutya((_kor + 1), _nev, _ehes); }
        public int Evszamkonvertalas() { return _kor * 7; }
    }
}
