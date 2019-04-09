using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbd3
{
    class Studentas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public double egzaminas { get; set; }
        public List<double> pazymiai { get; set; }
        public double nd_total1 { get; set; }
        public int kiekis { get; set; }

        public Studentas() { }
        public Studentas(string vard, string pav, double egz,List<double> pazymiai2,double nd_total, int kiekis1) {
            vardas = vard;
            pavarde = pav;
            egzaminas = egz;
            pazymiai = pazymiai2;
            nd_total1 = nd_total;
            kiekis = kiekis1;

        }

    }
}
