using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneZPlikuConsole
{
    class Program
    {
        static string TablicaDoString<T>(T[][] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    wynik += tab[i][j].ToString() + " ";
                }
                wynik = wynik.Trim() + Environment.NewLine;
            }

            return wynik;
        }

        static double StringToDouble(string liczba)
        {
            double wynik; liczba = liczba.Trim();
            if (!double.TryParse(liczba.Replace(',', '.'), out wynik) && !double.TryParse(liczba.Replace('.', ','), out wynik))
                throw new Exception("Nie udało się skonwertować liczby do double");

            return wynik;
        }


        static int StringToInt(string liczba)
        {
            int wynik;
            if (!int.TryParse(liczba.Trim(), out wynik))
                throw new Exception("Nie udało się skonwertować liczby do int");

            return wynik;
        }

        static string[][] StringToTablica(string sciezkaDoPliku)
        {
            string trescPliku = System.IO.File.ReadAllText(sciezkaDoPliku); // wczytujemy treść pliku do zmiennej
            string[] wiersze = trescPliku.Trim().Split(new char[] { '\n' }); // treść pliku dzielimy wg znaku końca linii, dzięki czemu otrzymamy każdy wiersz w oddzielnej komórce tablicy
            string[][] wczytaneDane = new string[wiersze.Length][];   // Tworzymy zmienną, która będzie przechowywała wczytane dane. Tablica będzie miała tyle wierszy ile wierszy było z wczytanego poliku

            for (int i = 0; i < wiersze.Length; i++)
            {
                string wiersz = wiersze[i].Trim();     // przypisuję i-ty element tablicy do zmiennej wiersz
                string[] cyfry = wiersz.Split(new char[] { ' ' });   // dzielimy wiersz po znaku spacji, dzięki czemu otrzymamy tablicę cyfry, w której każda oddzielna komórka to czyfra z wiersza
                wczytaneDane[i] = new string[cyfry.Length];    // Do tablicy w której będą dane finalne dokładamy wiersz w postaci tablicy integerów tak długą jak długa jest tablica cyfry, czyli tyle ile było cyfr w jednym wierszu
                for (int j = 0; j < cyfry.Length; j++)
                {
                    string cyfra = cyfry[j].Trim(); // przypisuję j-tą cyfrę do zmiennej cyfra
                    wczytaneDane[i][j] = cyfra; 
                }
            }
            return wczytaneDane;
        }

        static List<double> FindMin(string[][] data)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            var result = new List<double>();

            for (int i = 0; i < columnSize; i++)
            {
                double min = int.MaxValue;

                for (int j = 0; j < size; j++)
                {
                    double parsedData = StringToDouble(data[j][i]);
                    if (parsedData < min)
                    {
                        min = parsedData;
                    }
                }

                result.Add(min);
            }

            return result;
        }

        static List<double> FindMax(string[][] data)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            var result = new List<double>();

            for (int i = 0; i < columnSize; i++)
            {
                double max = int.MinValue;

                for (int j = 0; j < size; j++)
                {
                    double parsedData = StringToDouble(data[j][i]);
                    if (parsedData > max)
                    {
                        max = parsedData;
                    }
                }

                result.Add(max);
            }

            return result;
        }

        static void Main(string[] args)
        {
            string nazwaPlikuZDanymi = @"diabetes.txt";
            string nazwaPlikuZTypamiAtrybutow = @"diabetes-type.txt";

            string[][] wczytaneDane = StringToTablica(nazwaPlikuZDanymi);
            string[][] atrType = StringToTablica(nazwaPlikuZTypamiAtrybutow);

            Console.WriteLine("Dane systemu");
            string wynik = TablicaDoString(wczytaneDane);
            Console.Write(wynik);

            Console.WriteLine("");
            Console.WriteLine("Dane pliku z typami");

            string wynikAtrType = TablicaDoString(atrType);
            Console.Write(wynikAtrType);

            /****************** Miejsce na rozwiązanie *********************************/
            //Console.WriteLine(atrType[0][0]);
            //Console.WriteLine(atrType[0][1]);
            //Console.WriteLine(atrType[1][0]);
            //Console.WriteLine(atrType[1][1]);
            //Console.WriteLine(atrType[2][0]);
            //Console.WriteLine(atrType[2][1]);

            // Wielkości klas decyzyjnych
            Console.WriteLine(wczytaneDane.Length);

            var minResult = FindMin(wczytaneDane);

            Console.WriteLine("Minimalne: ");
            foreach (var item in minResult)
            {
                Console.WriteLine(item);
            }

            var maxResult = FindMax(wczytaneDane);

            Console.WriteLine("Maksymalne: ");
            foreach (var item in maxResult)
            {
                Console.WriteLine(item);
            }


            /****************** Koniec miejsca na rozwiązanie ********************************/
            Console.ReadKey();
        }
    }
}
