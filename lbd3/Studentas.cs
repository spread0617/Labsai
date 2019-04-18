using System.Collections.Generic;

namespace lbd3
{
    class Studentas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public double egzaminas { get; set; }
        public List<int> _pazymiai { get; set; }
        public double nd_total1 { get; set; }
        public int kiekis { get; set; }

        public Studentas() { }
        public Studentas(string vard, string pav, double egz,List<int> pazymiai2,double nd_total, int kiekis1) {
            vardas = vard;
            pavarde = pav;
            egzaminas = egz;
            _pazymiai = pazymiai2;
            nd_total1 = nd_total;
            kiekis = kiekis1;

        }

    }
}
