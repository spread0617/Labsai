using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbd3
{
    class Program
    {
        static List<Studentas> galvociai = new List<Studentas>();
        static List<Studentas> nuskriaustukai = new List<Studentas>();
        static List<Studentas> studentai = new List<Studentas>();
        static List<Studentas> _studentai = new List<Studentas>();
        static List<Studentas> RanStud = new List<Studentas>();
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
            try {
                while (testi)
                {
                    Console.WriteLine("1) Ivesti nauja studenta\n2) Galutiniam balui pagal vidurki\n3) Galutiniam balui pagal mediana\n4) Irasyti i faila\n5) Baigti darba");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("1)Is failo\n2)Klaviatura");
                            int choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    IsFailo();
                                    break;
                                case 2:
                                    PlusStud();
                                    pazymiai.Clear();
                                    nd_total = 0;
                                    break;
                            }
                            break;
                        case 2:
                            vidurkioSk();
                            break;
                        case 3:
                            medianosSkaiciavimas();
                            break;
                        case 4:
                            RasymasIFaila();
                            break;

                        case 5:
                            testi = false;
                            break;
                        default:
                            Console.WriteLine("Blogas pasirinkimas.");
                            break;


                    }




                    Console.ReadLine();
                }
            }catch(Exception e) { Console.WriteLine("Klaida: " + e); }


        }

        static public void IsFailo()
        {
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\domI\Desktop\Git\Labs\kursiokai.txt");
            //string[] words = file.ReadToEnd().Split(' ');
            try
            {
                using (var mappedFile1 = MemoryMappedFile.CreateFromFile(@"C:\Users\domI\Desktop\Git\Labs\kursiokai.txt"))
                {
                    using (Stream mmStream = mappedFile1.CreateViewStream())
                    {
                        using (StreamReader sr = new StreamReader(mmStream, Encoding.ASCII))
                        {
                            string headerLine = sr.ReadLine();
                            while (!sr.EndOfStream)
                            {
                                var line = sr.ReadLine();
                                var lineWords = line.Split(' ');
                                vardas = lineWords[0];
                                pavarde = lineWords[1];// out of bounds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                for (int i = 2; i < 6; i++)
                                {

                                    double pazymysRead = double.Parse(lineWords[i]);
                                    pazymiai.Add(pazymysRead);
                                    nd_total = nd_total + pazymysRead;
                                    /* double pazymysRead1 = double.Parse(lineWords[2]);
                                     double pazymysRead2 = double.Parse(lineWords[3]);
                                     double pazymysRead3 = double.Parse(lineWords[4]);
                                     double pazymysRead4 = double.Parse(lineWords[5]);
                                     double pazymysRead5 = double.Parse(lineWords[6]);
                                     pazymiai.Add(pazymysRead1, pazymysRead2, pazymysRead3, pazymysRead4, pazymysRead5);*/
                                }
                                egz_ivert = double.Parse(lineWords[7]);
                                studentai.Add(new Studentas(vardas, pavarde, egz_ivert, pazymiai, nd_total, 5));
                                pazymiai.Clear();
                                nd_total = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine("Klaida: " + e); }
        }
        static public void medianosSkaiciavimas()
        {
            Console.WriteLine("{0,-5 } {1,5 } {2,10 }", "Vardas", "Pavarde", "galutinis (Med.)");
            Console.WriteLine("----------------------------------");

            //int cnt = pazymiai.Count;

            try
            {
                foreach (var stud in studentai)
                {
                    stud.pazymiai.Sort();
                    if (stud.kiekis % 2 == 0)
                    {
                        double middleElement1 = stud.pazymiai[(stud.kiekis / 2) - 1]; //out of bounds!!!!!!!!!!!!!!!!!!!!!!!!
                        double middleElement2 = stud.pazymiai[(stud.kiekis / 2)];
                        mediana = (middleElement1 + middleElement2) / 2;

                    }
                    else
                    {
                        mediana = stud.pazymiai[(stud.kiekis / 2)]; //out of bounds!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    }

                    galutinis = (0.3 * mediana) + (0.7 * egz_ivert);

                    Console.WriteLine("{0,-5}{1,5}{2,10}", stud.vardas, stud.pavarde, galutinis);

                }
            }
            catch (Exception e) {
                Console.WriteLine("Klaida: " + e);
            }
        }




        static public void vidurkioSk()
        {

            //studentai = studentai.OrderBy(q => q).ToList();
            List<Studentas> SortedList = studentai.OrderBy(o => o.vardas).ToList();
            //studentai.Sort(new Comparison<Studentas>((x, y) => vardas.Compare(x.vardas, y.vardas)));
            Console.WriteLine("{0,-5 } {1,5 } {2,10 }", "Vardas", "Pavarde", "galutinis (Vid.)");
            Console.WriteLine("----------------------------------");
            try
            {
                foreach (var stud in studentai)
                {
                    double nd_ivert = stud.nd_total1 / stud.kiekis;
                    galutinis = (0.3 * nd_ivert) + (0.7 * stud.egzaminas);
                    Console.WriteLine("{0,-5}{1,5}{2,10}", stud.vardas, stud.pavarde, galutinis);
                }
            }
            catch (Exception e) {
                Console.WriteLine("Klaida: " + e);
            }
        }

        static public void PlusStud()
        {
            try
            {
                Console.WriteLine("Iveskite studento varda ir pavarde:");
                vardas = Console.ReadLine();
                pavarde = Console.ReadLine();

                Console.WriteLine("Iveskite namu darbu ivertinimu kieki:");
                int kiekiz = int.Parse(Console.ReadLine());
                Console.WriteLine("1) atsitiktinai sugeneruoti ivertinimai\n2) Ivesti ivertinimus ranka.");
                int choice2 = int.Parse(Console.ReadLine());
                if (choice2 == 1)
                {
                    int min = 0;
                    int max = 10;
                    int randomPazymys = 0;
                    Random RandNum = new Random();
                    for (int i = 0; i < kiekiz-1; i++)
                    {
                        randomPazymys = RandNum.Next(min, max);
                        pazymiai.Add(randomPazymys);
                    }

                }
                else
                {
                    Console.WriteLine("Iveskite studento namu darbu ivertinimus:");

                    for (int i = 0; i < kiekiz; i++)
                    {
                        Console.WriteLine("Iveskite studento {0} ivertinima", i);
                        pazymys = double.Parse(Console.ReadLine());
                        pazymiai.Add(pazymys);
                        nd_total = nd_total + pazymys;
                        skaitiklis++;
                    }
                }
                Console.WriteLine("Iveskite studento egzamino ivertinima:");
                egz_ivert = double.Parse(Console.ReadLine());
                studentai.Add(new Studentas(vardas, pavarde, egz_ivert, pazymiai, nd_total, kiekiz));

            }
            catch (Exception e) { Console.WriteLine("Klaida: " + e); }
        }

        static void RasymasIFaila() {
            try
            {
                foreach (var stud in studentai) {
                    double nd_ivert = stud.nd_total1 / stud.kiekis;
                    galutinis = (0.3 * nd_ivert) + (0.7 * stud.egzaminas);
                    if (galutinis >= 5)
                    {
                        galvociai.Add(new Studentas(stud.vardas, stud.pavarde, stud.egzaminas, stud.pazymiai, stud.nd_total1, stud.kiekis));
                    }
                    else if (galutinis < 5) {
                       nuskriaustukai.Add(new Studentas(stud.vardas, stud.pavarde, stud.egzaminas, stud.pazymiai, stud.nd_total1, stud.kiekis));
                    }

                }
                using (TextWriter tw = new StreamWriter(@"C:/Users/domI/Desktop/Git/Labs/nuskriaustukai.txt"))
                {
                    foreach (var nuskr in nuskriaustukai)
                        tw.WriteLine("{0} {1} {2} {3} {4}",nuskr.vardas, nuskr.pavarde, nuskr.pazymiai.ToString(),nuskr.egzaminas.ToString());
                }
                using (TextWriter tw = new StreamWriter(@"C:/Users/domI/Desktop/Git/Labs/genijai.txt"))
                {
                    foreach (var glv in galvociai)
                        tw.WriteLine("{0} {1} {2} {3} {4}", glv.vardas, glv.pavarde, glv.pazymiai.ToString(), glv.egzaminas.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Klaida: " + e);
            }
        }

       /* static void Generavimas() {
            try
            {
                string path10 = "C:/Users/domI/Desktop/Git/Labs/10.txt";
                string path100 = "C:/Users/domI/Desktop/Git/Labs/100.txt";
                string path1000 = "C:/Users/domI/Desktop/Git/Labs/1000.txt";
                string path10000 = "C:/Users/domI/Desktop/Git/Labs/10000.txt";

                FileStream fs10 = File.Create(@path10);
                FileStream fs100 = File.Create(@path100);
                FileStream fs1000 = File.Create(@path1000);
                FileStream fs10000 = File.Create(@path10000);

 
                
                string header = "Vardas Pavarde ND1 ND2 ND3 ND4 ND5 Egzaminas";
                
                System.IO.File.WriteAllText(@path10,header);
                System.IO.File.WriteAllText(@path100, header);
                System.IO.File.WriteAllText(@path1000, header);
                System.IO.File.WriteAllText(@path10000, header);

                for (int i = 0; i < 9; i++) {
                    string _vardas = "vardas{i}";
                    string _pavarde = "pavarde{i}";
                    int min = 0;
                    int max = 10;
                    int randomPazymys = 0;
                    Random RandNum = new Random();
                    double _egzas = RandNum.Next(min, max);
                    for (int j = 0; i < 4; i++)
                    {
                        randomPazymys = RandNum.Next(min, max);
                        pazymiai.Add(randomPazymys);
                    }
                    
                }

                using (FileStream fs = File.Open(path10))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    studentai.ForEach(r => sw.WriteLine(r));
                }

            }
            catch (Exception e) {
                Console.WriteLine("Klaida: " + e);
            }

        }*/




















    }
}
