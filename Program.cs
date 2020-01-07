using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidenca_Zaposlenih
{
    class Program
    {
        struct Zaposleni
        {
            public string delovnaŠtevilka;
            public string priimek;
            public string ime;
            public int delovnaDoba;
        }

        static Boolean IsAllLetters(String name)
        {
            for (Int32 i = 0; i < name.Length; i++)
            {
                if ((Int32)name[i] < 65 || ((Int32)name[i] > 90 && (Int32)name[i] < 97) || (Int32)name[i] > 122)
                    return false;
            }
            return true;
        }

        static Boolean IsAllNumbers(int numbers)
        {
            for (Int32 i = 0; i < 2; i++)
            {
                if ((Int32)numbers < 0 || ((Int32)numbers > 65))
                    return false;
            }
            return true;
        }

        static Boolean PreveriIme(String name)
        {
            for (Int32 i = 0; i < name.Length; i++)
            {
                if ((Int32)name[0] == 77 || (Int32)name[0] == 122 && (Int32)name[1] == 49 && (Int32)name[2] == 56 || (Int32)name[1] == 49 && (Int32)name[2] == 57 || (Int32)name[1] >= 50 && (Int32)name[1] <= 56 && (Int32)name[2] >= 48 && (Int32)name[2] <= 57 && (Int32)name[3] >= 48 && (Int32)name[3] <= 57 && (Int32)name[4] >= 48 && (Int32)name[4] <= 57 && (Int32)name[5] >= 48 && (Int32)name[5] <= 57)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Zaposleni[] zaposleni = new Zaposleni[10]; // Polje podatkov o najvec 10 zaposlenih.
            for (int i = 0; i <= 9; i = i + 1) // branje podatkov o zaposlenih
            {
                Console.WriteLine("{0}. Zaposleni>", i + 1);
                Console.Write("Delovna številka (Primer: Z22879 -> spol = Ž, starost = 22, DelovnoObmocje = 8, TipDela = 7, Pravice = 9):");
                zaposleni[i].delovnaŠtevilka = Console.ReadLine();
                while (zaposleni[i].delovnaŠtevilka.Length < 6)
                {
                    Console.Write("Delovna številka mora biti sestavljena iz vsaj sest crk/stevilk:");
                    zaposleni[i].delovnaŠtevilka = Console.ReadLine();
                }
                if (PreveriIme(zaposleni[i].delovnaŠtevilka) == true)
                {
                    Console.WriteLine("PRAV");
                }
                else
                {
                    Console.WriteLine("Napacen vnos.");
                    continue;
                }

                Console.Write("Vnesite Priimek:");
                zaposleni[i].priimek = Console.ReadLine();
                IsAllLetters(zaposleni[i].priimek);
                while (!IsAllLetters(zaposleni[i].priimek))
                {
                    Console.Write("Napacen vnos, prosimo vnesite ustrezen Priimek:");
                    zaposleni[i].priimek = Console.ReadLine();
                }
                Console.WriteLine("Ustrezen vnos.");


                Console.Write("Vnesite Ime:");
                zaposleni[i].ime = Console.ReadLine();
                IsAllLetters(zaposleni[i].ime);
                while (!IsAllLetters(zaposleni[i].ime))
                {
                    Console.Write("Napacen vnos, prosimo vnesite ustrezno Ime:");
                    zaposleni[i].ime = Console.ReadLine();
                }
                Console.WriteLine("Ustrezen vnos.");

                Console.Write("Vnesite Delovna dobo (v letih): ");
                zaposleni[i].delovnaDoba = int.Parse(Console.ReadLine());
                IsAllNumbers(zaposleni[i].delovnaDoba);
                while (!IsAllNumbers(zaposleni[i].delovnaDoba))
                {
                    Console.Write("Napacen vnos, prosimo vnesite ustrezno delovno dobo (v letih):");
                    zaposleni[i].delovnaDoba = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Ustrezen vnos.");

                Console.WriteLine("Želite dodati podatke o novem zaposlenem? Da/Ne: ");
                string dodatni = Console.ReadLine();
                while (dodatni != "Ne" || dodatni != "ne" || dodatni != "NE" || dodatni != "nE" || dodatni != "Da" || dodatni != "da" || dodatni != "DA" || dodatni != "dA")
                {
                    if (dodatni == "Da" || dodatni == "da" || dodatni == "DA" || dodatni == "dA")
                    {
                        break;
                    }
                    else if (dodatni == "Ne" || dodatni == "ne" || dodatni == "NE" || dodatni == "nE")
                    {
                        Console.WriteLine("Vnosi koncani.");
                        Console.WriteLine("Vnesite ime datoteke: ");
                        var ime = Console.ReadLine();
                        string filePath = @"C:\Users\Minej\Desktop\" + ime + ".txt";
                        using (StreamWriter outputFile = new StreamWriter(filePath))
                        {
                            outputFile.WriteLine("-------------------------");
                            outputFile.WriteLine("Delovna številka: " + zaposleni[i].delovnaŠtevilka);
                            outputFile.WriteLine("Priimek zaposlenega: " + zaposleni[i].priimek);
                            outputFile.WriteLine("Ime zaposlenega: " + zaposleni[i].ime);
                            outputFile.WriteLine("Delovna doba zaposlenega:" + zaposleni[i].delovnaDoba);
                        }
                        return;
                    }
                        Console.WriteLine("Napacen vnos, prosim vnesite Da ali Ne.");
                        dodatni = Console.ReadLine();
                }
            }
        }
    }
}
