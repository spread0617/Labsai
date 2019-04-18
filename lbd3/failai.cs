using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbd3
{
    class failai
    {
        static List<Studentas> _studentai10 = new List<Studentas>();
        static List<Studentas> _studentai100 = new List<Studentas>();
        static List<Studentas> _studentai1000 = new List<Studentas>();
        static List<Studentas> _studentai10000 = new List<Studentas>();
        

        public static void GenerateRandomStudentList()
        {

            string path10 = "C:\\temp\\studentai10.txt";
            string path100 = "C:\\temp\\studentai100.txt";
            string path1000 = "C:\\temp\\studentai1000.txt";
            string path10000 = "C:\\temp\\studentai10000.txt";
            if (File.Exists(path10) == false || File.Exists(path100) == false || File.Exists(path1000) == false || File.Exists(path1000) == false)
            {
                Console.WriteLine("Sugeneruoti failai bus issaugoti: ");
                Console.WriteLine(path10);
                Console.WriteLine(path100); Console.WriteLine(path1000); Console.WriteLine(path10000);
                Random random = new Random();

                List<string> allLines10 = new List<string>();
                List<string> allLines100 = new List<string>();
                List<string> allLines1000 = new List<string>();
                List<string> allLines10000 = new List<string>();
                string header = string.Format("{0,-20} {1,-20} {2, -20} {3, -20} {4, -20} {5, -20} {6, -20} {7, -20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "Egzaminas");

                allLines10.Add(header);
                allLines100.Add(header);
                allLines1000.Add(header);
                allLines10000.Add(header);

                var watch = new System.Diagnostics.Stopwatch();


                watch.Start();

                for (int i = 1; i <= 10; i++)
                {
                    string vardas = "Vardas" + i;
                    string pavarde = "Pavarde" + i;
                    _studentai10.Add(new Studentas(vardas, pavarde));
                    string line = string.Format("{0,-20} {1,-20}", vardas, pavarde);
                    for (int j = 0; j < 5; j++)
                    {
                        int pazimys = random.Next(1, 11);
                        line += string.Format("{0,-20}", pazimys);
                        _studentai10.Last().ivestiNamuDarboBala(pazimys);
                    }
                    int egzas = random.Next(1, 11);
                    line += string.Format("{0,-20} \n", egzas);
                    _studentai10.Last().ivestiEgzaminoBala(egzas);

                    allLines10.Add(line);
                }

                for (int i = 1; i <= 100; i++)
                {
                    string vardas = "Vardas" + i;
                    string pavarde = "Pavarde" + i;
                    _studentai100.Add(new Studentas(vardas, pavarde));
                    string line = string.Format("{0,-20} {1,-20}", vardas, pavarde);
                    for (int j = 0; j < 5; j++)
                    {
                        int pazimys = random.Next(1, 11);
                        line += string.Format("{0,-20}", pazimys);
                        _studentai100.Last().ivestiNamuDarboBala(pazimys);
                    }
                    int egzas = random.Next(1, 11);
                    line += string.Format("{0,-20} \n", egzas);
                    _studentai100.Last().ivestiEgzaminoBala(egzas);

                    allLines100.Add(line);
                }

                for (int i = 1; i <= 1000; i++)
                {
                    string vardas = "Vardas" + i;
                    string pavarde = "Pavarde" + i;
                    _studentai1000.Add(new Studentas(vardas, pavarde));
                    string line = string.Format("{0,-20} {1,-20}", vardas, pavarde);
                    for (int j = 0; j < 5; j++)
                    {
                        int pazimys = random.Next(1, 11);
                        line += string.Format("{0,-20}", pazimys);
                        _studentai1000.Last().ivestiNamuDarboBala(pazimys);
                    }
                    int egzas = random.Next(1, 11);
                    line += string.Format("{0,-20} \n", egzas);
                    _studentai1000.Last().ivestiEgzaminoBala(egzas);

                    allLines1000.Add(line);
                }

                for (int i = 1; i <= 10000; i++)
                {
                    string vardas = "Vardas" + i;
                    string pavarde = "Pavarde" + i;
                    _studentai10000.Add(new Studentas(vardas, pavarde));
                    string line = string.Format("{0,-20} {1,-20}", vardas, pavarde);
                    for (int j = 0; j < 5; j++)
                    {
                        int pazimys = random.Next(1, 11);
                        line += string.Format("{0,-20}", pazimys);
                        _studentai10000.Last().ivestiNamuDarboBala(pazimys);
                    }
                    int egzas = random.Next(1, 11);
                    line += string.Format("{0,-20} \n", egzas);
                    _studentai10000.Last().ivestiEgzaminoBala(egzas);

                    allLines10000.Add(line);
                }

                watch.Stop();
                Console.WriteLine("It took {0} miliseconds to complete this task.", watch.ElapsedMilliseconds);
                File.AppendAllLines(path10, allLines10);
                File.AppendAllLines(path100, allLines100);
                File.AppendAllLines(path1000, allLines1000);
                File.AppendAllLines(path10000, allLines10000);
            }
            else { Console.WriteLine("Failai jau sukurti."); }

        }






        static public List<Studentas> IsFailo(List<Studentas> studentaiF)
        {


            Console.WriteLine("Iveskite failo vieta (path):");
            var path = Console.ReadLine();
            if (File.Exists(path))

            {
                try
                {
                    var tekstas = File.ReadAllLines(path);
                    var title = tekstas[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    int n = 1;
                    while (n < tekstas.Length)
                    {
                        var eilute = tekstas[n].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        studentaiF.Add(new Studentas(eilute[0], eilute[1]));
                        for (int i = 2; i < title.Length - 1; i++)
                        {
                            studentaiF.Last().ivestiNamuDarboBala(int.Parse(eilute[i]));
                        }
                        studentaiF.Last().ivestiEgzaminoBala(int.Parse(eilute[title.Length - 1]));
                        n++;
                    }
                }
                catch (Exception e) { Console.WriteLine("Klaida: " + e); }
                }
            else
            {
                Console.WriteLine("Tokio failo nera.");
            }

            return studentaiF;
        }





    }



}
