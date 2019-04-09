using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbd3
{
    class Program
    {
        static List<Studentas> studentai = new List<Studentas>();
        static double pazymys;
        static List<double> pazymiai = new List<double>();
        static double nd_total = 0;
        static int skaitiklis = 0;
        static string vardas;
        static string pavarde;
        static double galutinis = 0;
        static double egz_ivert = 0;
        static double mediana = 0;
        static void Main(string[] args)
        {





            bool testi = true;
            while (testi)
            {
                Console.WriteLine("1)Ivesti nauja studenta\n2) Galutiniam balui pagal vidurki\n3) Galutiniam balui pagal mediana\n4) Baigti darba");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PlusStud();
                        pazymiai.Clear();
                        nd_total = 0;
                        break;
                    case 2:
                        vidurkioSk();
                        break;
                    case 3:
                        medianosSkaiciavimas();
                        break;
                    case 4:
                        testi = false;
                        break;
                    default:
                        Console.WriteLine("Blogas pasirinkimas.");
                        break;


                }




                Console.ReadLine();
            }

        }



        static public void PlusStud()
        {
            Console.WriteLine("Iveskite studento varda ir pavarde:");
            vardas = Console.ReadLine();
            pavarde = Console.ReadLine();
            
            Console.WriteLine("Iveskite namu darbu ivertinimu kieki:");
            int kiekiz = int.Parse(Console.ReadLine());
            Console.WriteLine("1) atsitiktinai sugeneruoti ivertinimai\n2) Ivesti ivertinimus ranka.");
            int choice2 = int.Parse(Console.ReadLine());
            if(choice2 == 1){
                int min= 0;
                int max= 10;
                int randomPazymys = 0;
                Random RandNum = new Random();
                for(int i = 0; i<kiekiz;i++){
                   randomPazymys = RandNum.Next(min,max);
                    pazymiai.Add(randomPazymys);
                }

                }else{
            Console.WriteLine("Iveskite studento namu darbu ivertinimus:");

            for(int i = 0; i<kiekiz;i++)
            {
                Console.WriteLine("Iveskite studento {0} ivertinima",i);
                pazymys = double.Parse(Console.ReadLine());
                pazymiai.Add(pazymys);
                nd_total = nd_total + pazymys;
                skaitiklis++;
            }
            }
            Console.WriteLine("Iveskite studento egzamino ivertinima:");
            egz_ivert = double.Parse(Console.ReadLine());
            studentai.Add(new Studentas(vardas, pavarde, egz_ivert, pazymiai, nd_total,kiekiz));
            

        }








        static public void vidurkioSk()
        {
          
                
               
            Console.WriteLine("{0,-5 } {1,5 } {2,10 }", "Vardas", "Pavarde", "galutinis (Vid.)");
            Console.WriteLine("----------------------------------");
            foreach (var stud in studentai)
            {
                double nd_ivert = stud.nd_total1 / stud.kiekis;
                galutinis = (0.3 * nd_ivert) + (0.7 * stud.egzaminas);
                Console.WriteLine("{0,-5}{1,5}{2,10}", stud.vardas, stud.pavarde, galutinis);
            }
        }







        static public void medianosSkaiciavimas()
        {
            Console.WriteLine("{0,-5 } {1,5 } {2,10 }", "Vardas", "Pavarde", "galutinis (Med.)");
            Console.WriteLine("----------------------------------");
            
            //int cnt = pazymiai.Count;
            

            foreach (var stud in studentai)
            {
                stud.pazymiai.Sort();
                if (stud.kiekis % 2 == 0)
                {
                    double middleElement1 = stud.pazymiai[(stud.kiekis / 2) - 1];
                    double middleElement2 = stud.pazymiai[(stud.kiekis / 2)];
                    mediana = (middleElement1 + middleElement2) / 2;

                }
                else
                {
                    mediana = stud.pazymiai[(stud.kiekis / 2)];
                }

                galutinis = (0.3 * mediana) + (0.7 * egz_ivert);
               
                Console.WriteLine("{0,-5}{1,5}{2,10}", stud.vardas, stud.pavarde, galutinis);
            }
        }
    }
}
