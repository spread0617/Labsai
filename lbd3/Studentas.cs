using System.Collections.Generic;

namespace lbd3
{
    class Studentas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public double egzaminas { get; set; }
        public List<int> _pazymiai = new List<int>();
        public double nd_total1 { get; set; }
        public int kiekis { get; set; }

        public Studentas() { }

        public Studentas(string vardas, string pavarde)
        {
            this.vardas = vardas;
            this.pavarde = pavarde;
        }

        public Studentas(string vard, string pav, double egz,List<int> pazymiai2,double nd_total, int kiekis1) {
            vardas = vard;
            pavarde = pav;
            egzaminas = egz;
            _pazymiai = pazymiai2;
            nd_total1 = nd_total;
            kiekis = kiekis1;

        }

        class CompareStudentas : IComparer<Studentas>
        {
            public int Compare(Studentas x, Studentas y)
            {
                return x.vardas.CompareTo(y.vardas);
            }
        }

        public void ivestiNamuDarboBala(int _pazymys)
        {
            this._pazymiai.Add(_pazymys);
        }

        public void ivestiEgzaminoBala(int balas)
        {
            this.egzaminas = balas;
        }

    }
}
