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
        static List<Studentas> RanStud = new List<Studentas>();
        static int pazymys;
        static List<int> pazymiai = new List<int>();
        static double nd_total = 0;
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
                    Console.WriteLine("1) Ivesti nauja studenta\n2) Galutiniam balui pagal vidurki\n3) Galutiniam balui pagal mediana\n4) Suskirstyti studentus i 'nuskriaustukus' ir galvocius + issaugoti srasus faile.\n5) Baigti darba\n99) Sugeneruoti random studentu failus.");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("1)Is failo\n2)Klaviatura");
                            int choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    studentai = failai.IsFailo(studentai);
                                
                                break;
                                case 2:
                                    PlusStud();
                                
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
                    case 99:
                            failai.GenerateRandomStudentList();
                        break;
                        default:
                            Console.WriteLine("Blogas pasirinkimas.");
                            break;


                    }




                    Console.ReadLine();
                }
            }catch(Exception e) { Console.WriteLine("Klaida: " + e); }


        }
        

        static public void medianosSkaiciavimas()
        {
            
                Console.WriteLine("{0,-5 } {1,5 } {2,10 }", "Vardas", "Pavarde", "galutinis (Med.)");
                Console.WriteLine("----------------------------------");

                //int cnt = pazymiai.Count;

                try
                {
                //foreach (var stud in studentai)
                for(int i=0;i<studentai.Count();i++)
                {
                    studentai[i]._pazymiai.Sort();
                    if (studentai[i].kiekis % 2 == 0)
                    {
                        double middleElement1 = studentai[i]._pazymiai[(studentai[i].kiekis / 2) - 1]; 
                        double middleElement2 = studentai[i]._pazymiai[(studentai[i].kiekis / 2)];
                        mediana = (middleElement1 + middleElement2) / 2;

                    }
                    else
                    {
                        mediana = studentai[i]._pazymiai[(studentai[i].kiekis / 2)]; 
                    }

                    galutinis = (0.3 * mediana) + (0.7 * egz_ivert);

                    Console.WriteLine("{0,-5}{1,5}{2,10}", studentai[i].vardas, studentai[i].pavarde, galutinis);

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
                pazymiai.Clear();
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
                        nd_total += randomPazymys;
                    }

                }
                else
                {
                    Console.WriteLine("Iveskite studento namu darbu ivertinimus:");

                    for (int i = 1; i < kiekiz; i++)
                    {
                        Console.WriteLine("Iveskite studento {0} ivertinima", i);
                        pazymys = int.Parse(Console.ReadLine());
                        pazymiai.Add(pazymys);
                        nd_total += pazymys;
                        
                    }
                   
                }
                Console.WriteLine("Iveskite studento egzamino ivertinima:");
                egz_ivert = double.Parse(Console.ReadLine());
                studentai.Add(new Studentas(vardas, pavarde, egz_ivert, pazymiai, nd_total, kiekiz));
               
                nd_total = 0;
            }
            catch (Exception e) { Console.WriteLine("Klaida: " + e); }
        }

        static void RasymasIFaila() {
            try
            {
                //foreach (var std in studentai)
                for(int i = 0;i<studentai.Count();i++)
                {
                    if (studentai[i].nd_total1 / studentai[i].kiekis < 5)
                    {
                        nuskriaustukai.Add(studentai[i]);
                    }
                    else if (studentai[i].nd_total1 / studentai[i].kiekis >= 5)
                    {
                        galvociai.Add(studentai[i]);
                    }
                    else Console.WriteLine("Sitas studentas isvis kazkoks nesusipratimas.: " + studentai[i].vardas);

                }
                using (FileStream fs = new FileStream(@"C:/Temp/nuskriaustukai.txt", FileMode.Append, FileAccess.Write))
                using (TextWriter tw = new StreamWriter(fs))
                {
                    //foreach (var nuskr in nuskriaustukai)
                    for (int i = 0; i < nuskriaustukai.Count(); i++)
                        tw.WriteLine("{0} {1}", nuskriaustukai[i].vardas, nuskriaustukai[i].pavarde);
                }
                using (FileStream fs1 = new FileStream(@"C:/Temp/genijai.txt", FileMode.Append, FileAccess.Write))
                using (TextWriter tw1 = new StreamWriter(fs1))
                {
                    //foreach (var glv in galvociai)
                    for(int i=0; i<galvociai.Count();i++)
                        tw1.WriteLine("{0} {1}", galvociai[i].vardas, galvociai[i].pavarde);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Klaida: " + e);
            }
        }




















    }
}
