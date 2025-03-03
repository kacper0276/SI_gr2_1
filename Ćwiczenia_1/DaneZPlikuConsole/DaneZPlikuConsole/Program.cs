using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;

namespace DaneZPlikuConsole
{
    class UniqueSet<T>: List<T>
    {
        public new void Add(T obj)
        {
            if (!Contains(obj))
            {
                base.Add(obj);
            }
        }
    }

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

        static List<double> Avg(string[][] data)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            var result = new List<double>();

            for (int i = 0; i < columnSize; i++)
            {
                double sum = 0;

                for (int j = 0; j < size; j++)
                {
                    double parsedData = StringToDouble(data[j][i]);
                    sum += parsedData;
                }

                result.Add(sum / size);
            }

            return result;
        }

        public static void FillMissingValues(string[][] data)
        {
            int rows = data.Length;
            int cols = data[0].Length;

            for (int j = 0; j < cols; j++)
            {
                Dictionary<string, int> frequency = new Dictionary<string, int>();
                double sum = 0;
                int count = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (data[i][j] != "?")
                    {
                        if (double.TryParse(data[i][j], out double num))
                        {
                            sum += num;
                            count++;
                        }
                        else
                        {
                            if (!frequency.ContainsKey(data[i][j]))
                                frequency[data[i][j]] = 0;
                            frequency[data[i][j]]++;
                        }
                    }
                }

                string mostCommon = frequency.OrderByDescending(x => x.Value).FirstOrDefault().Key;
                string replacement = count > 0 ? (sum / count).ToString() : mostCommon;

                for (int i = 0; i < rows; i++)
                {
                    if (data[i][j] == "?")
                    {
                        data[i][j] = replacement;
                    }
                }
            }
        }

        static UniqueSet<double> getUnique(string[][] data)
        {
            var result = new UniqueSet<double>();
            int size = data.Length;
            int columnSize = data[0].Length;

            for (int i = 0; i < columnSize; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    double parsedData = StringToDouble(data[j][i]);
                    result.Add(parsedData);
                }
            }

            return result;
        }

        static UniqueSet<double> getUniqueForColumn(string[][] data, int column)
        {
            var result = new UniqueSet<double>();
            int size = data.Length;

            for (int j = 0; j < size; j++)
            {
                double parsedData = StringToDouble(data[j][column]);
                result.Add(parsedData);
            }

            return result;
        }

        static double CalculateStandardDeviation(List<string> data)
        {
            List<double> numericData = data.Select(x => StringToDouble(x)).ToList();

            double mean = numericData.Average();

            double sumOfSquares = numericData.Sum(x => Math.Pow(x - mean, 2));

            double variance = sumOfSquares / numericData.Count;

            return Math.Sqrt(variance);
        }

        
        static string[][] NormalizeIntoIntervals(string[][] data, double a, double b)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            List<double> minResults = FindMin(data);
            List<double> maxResults = FindMax(data);

            for (int j = 0; j < columnSize; j++)
            {
                if(minResults[j] == maxResults[j])
                {
                    continue;
                }
                for (int i = 0; i < size; i++)
                {
                    double parsedData = StringToDouble(data[i][j]);
                    double normalizedValue = ((b - a) * (parsedData - minResults[j])) / (maxResults[j] - minResults[j]) + a;
                    data[i][j] = normalizedValue.ToString("F2");//Przybliżenie do dwóch miejsc po przecinku by dane były czytelne
                }
            }
            return data;
        }
        static List<double> StdDev(string[][] data)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            var result = new List<double>();

            for (int i = 0; i < columnSize; i++)
            {
                var columnData = new List<string>();

                for (int j = 0; j < size; j++)
                {
                    columnData.Add(data[j][i]);
                }

                double stdDev = CalculateStandardDeviation(columnData);
                result.Add(stdDev);
            }

            return result;
        }
        static string[][] Normalize(string[][] data)
        {

            int size = data.Length;
            int columnSize = data[0].Length;
            List<double> averages = Avg(data);
            List<double> stdDevs = StdDev(data);

            for (int j = 0; j < columnSize; j++)
            {
                if (stdDevs[j]==0)
                {
                    continue;
                }
                for (int i = 0; i < size; i++)
                {
                    double parsedData = StringToDouble(data[i][j]);
                    double normalizedValue = (parsedData - averages[j]) / stdDevs[j];
                    data[i][j] = normalizedValue.ToString("G");
                }
            }
            return data;
        }
        static double CalculateVariance(List<string> data)
        {
            List<double> numericData = data.Select(x => StringToDouble(x)).ToList();

            double mean = numericData.Average();

            double sumOfSquares = numericData.Sum(x => Math.Pow(x - mean, 2));

            return sumOfSquares / numericData.Count;
        }
        static List<double> Variance(string[][] data)
        {
            int size = data.Length;
            int columnSize = data[0].Length;
            var result = new List<double>();

            for (int i = 0; i < columnSize; i++)
            {
                var columnData = new List<string>();

                for (int j = 0; j < size; j++)
                {
                    columnData.Add(data[j][i]);
                }

                double stdDev = CalculateVariance(columnData);
                result.Add(stdDev);
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

            // Lista wszystikch
            var uniq = getUnique(wczytaneDane);

            foreach (var item in uniq)
            {
                Console.WriteLine(item);
            }

            // Poszczególne
            for (int i = 0; i < wczytaneDane[0].Length; i++)
            {
                var uniqueForColumn = getUniqueForColumn(wczytaneDane, i);

                foreach (var item in uniqueForColumn)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Liczba wszystkich: " + uniqueForColumn.Count);

                Console.WriteLine("--------------------------");
            }

            // Odchylenie standardowe
            int length = wczytaneDane.Length;
            for (int i = 0; i < wczytaneDane[0].Length; i++)
            {
                List<string> data = new List<string>();

                for (int j = 0; j < length; j++)
                {
                    data.Add(wczytaneDane[j][i]);
                }

                var standardDeviation = CalculateStandardDeviation(data);
                Console.WriteLine(standardDeviation);
            }
            // Zadanie 4 i 5
            // Generowanie 10%
            int originalRows = wczytaneDane.Length;
            int cols = wczytaneDane[0].Length;
            int extraRows = originalRows / 10;
            int newRows = originalRows + extraRows;

            string[][] expandedData = new string[newRows][];

            for (int i = 0; i < originalRows; i++)
            {
                expandedData[i] = new string[cols];
                Array.Copy(wczytaneDane[i], expandedData[i], cols);
            }
            
            for (int i = originalRows; i < newRows; i++)
            {
                expandedData[i] = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    expandedData[i][j] = "?";
                }
            }

            string[][] normalizedData = NormalizeIntoIntervals(wczytaneDane, -1, 1);
            Console.WriteLine("Dane znormalizowane na przedział <-1, 1>\n");
            foreach (var row in normalizedData)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            string[][] normalizedData2 = NormalizeIntoIntervals(wczytaneDane, 0, 1);
            Console.WriteLine("Dane znormalizowane na przedział <0, 1>\n");
            foreach (var row in normalizedData2)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            string[][] normalizedData3 = NormalizeIntoIntervals(wczytaneDane, -10, 10);
            Console.WriteLine("Dane znormalizowane na przedział <-10,10>");
            foreach (var row in normalizedData3)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            string[][] normalizedData4 = Normalize(wczytaneDane);
            Console.WriteLine("Dane znormalizowane");
            foreach (var row in normalizedData4)
            {
                Console.WriteLine(string.Join(" ", row.Select(value => double.Parse(value).ToString("F2"))));
            }

            List<double>averageValues = Avg(normalizedData4);
            Console.WriteLine(string.Join(" ", averageValues));
            //otrzymane wartości nie są dokładnie równe zero ale bliskie jemu z powodu zaokrąglania
            List<double> variances = Variance(normalizedData4);
            Console.WriteLine(string.Join(" ", variances));
            //wartości są równe lub bardzo zbliżone do 1



            //wczytanie pliku CSV
            List<Dictionary<string, string>> readableData = new List<Dictionary<string, string>>();
            UniqueSet<string> geographyValues = new UniqueSet<string>();
            using (var reader = new StreamReader(@"Churn_Modelling.csv"))
            {
                string headerLine = reader.ReadLine();
                var headers = headerLine.Split(',');

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var rowDict = new Dictionary<string, string>();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        string header = headers[i];
                        rowDict[headers[i]] = values.Length > i ? values[i] : "MISSING";
                        if (header == "Geography")
                        {
                            geographyValues.Add(values[i]);
                        }
                    }

                    readableData.Add(rowDict);
                }
            }


            //tworzenie dummy attributes dla kolumny Geography
            foreach (var row in readableData)
            {
                foreach (var country in geographyValues)
                {
                    row[country] = (row["Geography"] == country) ? "1" : "0";
                }
                row.Remove("Geography");
                row.Remove(geographyValues[0]);//usunięcie jednego z dummy attributes
            }

            foreach (var row in readableData)
            {
                foreach (var kvp in row)
                {
                    Console.Write($"{kvp.Key}: {kvp.Value}  ");
                }
                Console.WriteLine();
            }
            /****************** Koniec miejsca na rozwiązanie ********************************/
            Console.ReadKey();
        }
    }
}
