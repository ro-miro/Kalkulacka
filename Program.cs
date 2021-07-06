using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_ukol04
{
    class Kalkulacka
    {
        public double MatVysledek;
        public string MatOperator;
        public double PrvniCislo;
        public double DruheCislo;
        public double ZahajovaciCislo;
        public bool JeMatOperator;

        public void ProvedVypocet()
        {
            if (MatOperator == "+")
            {
                MatVysledek = PrvniCislo + DruheCislo;
            }
            else if (MatOperator == "-")
            {
                MatVysledek = PrvniCislo - DruheCislo;
            }
            else if (MatOperator == "*")
            {
                MatVysledek = PrvniCislo * DruheCislo;
            }
            else if (MatOperator == "/")
            {
                MatVysledek = PrvniCislo / DruheCislo;
            }
            else if (MatOperator == "^")
            {
                MatVysledek = 1;

                for (int f = 0; f < DruheCislo; f = f + 1)
                {
                    MatVysledek = PrvniCislo * MatVysledek;
                }
            }
        }
        public bool JeOperator()
        {
            bool JeMatOperator = (MatOperator == "+") || (MatOperator == "-") || (MatOperator == "*") || (MatOperator == "/") || (MatOperator == "^");
            return JeMatOperator;
        }
    }
    class Program
    {
        static void Main()
        {
            Kalkulacka kalkulacka = new Kalkulacka();

            Console.WriteLine("Kalkulačka pro sčítání, odečítání, násobení, dělení a mocnění.Kalkulačku ukončíš klávesou x");
            Console.WriteLine();

            // ZADANI PRVNIHO CISLA

            Console.WriteLine("Zadej první číslo: ");
            string zahajovaciCisloText = Console.ReadLine();

            bool jeZahajovaciCislo = double.TryParse(zahajovaciCisloText, out kalkulacka.ZahajovaciCislo);

            while (!jeZahajovaciCislo)
            {
                if (zahajovaciCisloText == "x")
                {
                    return;
                }

                Console.WriteLine("Špatně zadané první číslo. Zkus to znovu.");
                zahajovaciCisloText = Console.ReadLine();
                jeZahajovaciCislo = double.TryParse(zahajovaciCisloText, out kalkulacka.ZahajovaciCislo);
            }

            double matVysledekJakoPrvniCislo = kalkulacka.ZahajovaciCislo;

            // ZADANI OPERATORU

            while (true)
            {
                kalkulacka.PrvniCislo = matVysledekJakoPrvniCislo;

                Console.WriteLine();
                Console.WriteLine("Zadej operátor (+, -, *, /, ^) nebo klávesou x ukonči program. ");
                kalkulacka.MatOperator = Console.ReadLine();

                if (kalkulacka.MatOperator == "x")
                {
                    return;
                }


                while (!kalkulacka.JeOperator())
                {
                    Console.WriteLine("S tímto znakem nemohu provést operaci. Zkus zadat operátor znovu (+, -, *, /, ^) nebo klávesou x ukonči program. ");
                    kalkulacka.MatOperator = Console.ReadLine();
                }

                // ZADANI DRUHEHO CISLA

                Console.WriteLine();
                Console.WriteLine("Zadej další číslo: ");
                string druheCisloText = Console.ReadLine();

                bool jeDruheCislo = double.TryParse(druheCisloText, out kalkulacka.DruheCislo);

                kalkulacka.MatVysledek = 0;

                while (!jeDruheCislo)
                {
                    if (druheCisloText == "x")
                    {
                        return;
                    }
                    Console.WriteLine("Špatně zadané druhé číslo. Zkus to znovu.");
                    druheCisloText = Console.ReadLine();
                    jeDruheCislo = double.TryParse(druheCisloText, out kalkulacka.DruheCislo);
                }

                // NECHCI DELIT NULOU

                if (kalkulacka.MatOperator == "/")
                {
                    while (kalkulacka.DruheCislo == 0 || jeDruheCislo == false)
                    {
                        Console.WriteLine("Nemůžeme jiné číslo dělit nulou nebo znakem, který není číslem . Zkus to znovu. ");
                        druheCisloText = Console.ReadLine();
                        jeDruheCislo = double.TryParse(druheCisloText, out kalkulacka.DruheCislo);
                    }
                }

                // NECHCI MOCNIT ZAPORNYM CISLEM

                if (kalkulacka.MatOperator == "^")
                {
                    while (kalkulacka.DruheCislo < 0 || jeDruheCislo == false)
                    {
                        Console.WriteLine("Zadaný znak je nepovolený nebo se jedná o záporné číslo. Zadej prosím celé nezáporné číslo.");
                        druheCisloText = Console.ReadLine();
                        jeDruheCislo = double.TryParse(druheCisloText, out kalkulacka.DruheCislo);
                    }
                }
                
                // VYPOCET

                kalkulacka.ProvedVypocet();
                matVysledekJakoPrvniCislo = kalkulacka.MatVysledek;
                Console.WriteLine();
                Console.WriteLine("Výsledek: " + kalkulacka.PrvniCislo + kalkulacka.MatOperator + kalkulacka.DruheCislo + " = " + matVysledekJakoPrvniCislo);
            }
        }
    }
}
