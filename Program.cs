using System;
using System.Diagnostics;
using System.Threading;

namespace ProjektBubbleSort
{
    class Program
    {
        #region Komponenty
        public static int[] GenerujLiczby(int length)
        {
            int[] tablicaLiczb = new int[length];
            Random liczbaLosowa = new Random();

            for(int i=0; i < tablicaLiczb.Length; i++)
            {
                int elementTablicy = liczbaLosowa.Next(0, 50);
                tablicaLiczb[i] = elementTablicy;
            }
            return tablicaLiczb;
        }
        #endregion
        #region Sortowanie bąbelkowe
        public static void SortowanieBabelkowe(int[] tablica)
        {
            int temp = 0;
            for (int i = 0; i < tablica.Length - 1; i++)
            {
                for (int j = 0; j < tablica.Length - 1 - i; j++)
                {
                    if (tablica[j] > tablica[j + 1])
                    {
                        temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;
                    }
                }
            }
        }
        #endregion
        #region Czas Wykonania
        public static void CzasWykonania()
        {
            int[] tablicaMala = GenerujLiczby(300);
            int[] tablicaSrednia = GenerujLiczby(2000);
            int[] tablicaDuza = GenerujLiczby(7000);

            Console.WriteLine("Czas sortowania bąbelkowego przy porządkowaniu zbioru 300 elementowego:");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortowanieBabelkowe(tablicaMala);
            stopwatch.Stop();
            TimeSpan czas = stopwatch.Elapsed;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(czas.Duration());
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Czas sortowania bąbelkowego przy porządkowaniu zbioru 2000 elementowego:");
            stopwatch.Reset();
            stopwatch.Start();
            SortowanieBabelkowe(tablicaSrednia);
            stopwatch.Stop();
            czas = stopwatch.Elapsed;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(czas.Duration());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Czas sortowania bąbelkowego przy porządkowaniu zbioru 7000 elementowego");
            stopwatch.Reset();
            stopwatch.Start();
            SortowanieBabelkowe(tablicaDuza);
            stopwatch.Stop();
            czas = stopwatch.Elapsed;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(czas.Duration());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować program");
            Console.ReadKey();
        }
        #endregion
        #region Definicje
        public static void Definicje()
        {
            Console.WriteLine("Sortowanie bąbelkowe polega na porównaniu dwóch elementów znajdujących się obok siebie ");
            Console.WriteLine("i zamianie ich miejscami, gdy liczby nie spełniają założenia kolejności jaka została obrana.");
            Console.WriteLine("Sortowanie kończy się, gdy podczas kolejnego przejścia nie dokonano żadnej zmiany.");
            Console.WriteLine("Jest to jeden z najprostszych algorytmów sortowania. Zaletą sortowania bąbelkowego jest jego prostota");
            Console.WriteLine("i bardzo krótki kod. Jego główną wadą jest to, że zawsze, niezależnie od danych, wykonuje tyle samo porównań.");
            Console.WriteLine(" ");
            Console.WriteLine("Aby przejść dalej, kliknij dowolny klawisz");
            Console.ReadKey();
        }
        #endregion
        #region Przedstawienie Alfanumeryczne
        public static void Alfanumeryczna()
        {
            int[] tablica = GenerujLiczby(10);
            int iteracja = 1;
            int temp = 0;

            Console.Clear();
            Console.WriteLine("Wylosowane zostały następujące liczby:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.Write(tablica[i] + " ");
            }
            Console.Write("\n");

            for (int i = 0; i < tablica.Length - 1; i++)
            {
                for (int j = 0; j < tablica.Length - 1 - i; j++)
                {
                    if (tablica[j] > tablica[j + 1])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("Iteracja " + iteracja + ": ");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        for (int k = 0; k < j; k++)
                        {
                            Console.Write(tablica[k] + " ");
                        }
                        temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(tablica[j] + " " + tablica[j + 1] + " ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        for (int k = j + 2; k < tablica.Length; k++)
                        {
                            Console.Write(tablica[k] + " ");
                        }
                        Console.Write("\n");
                    }
                }
                iteracja += 1;
            }

            Console.WriteLine("\nTablica po sortowaniu:");
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.Write(tablica[i] + " ");
            }
            Console.ReadKey();
        }

        #endregion
        #region Przedstawienie Graficzne
   
        public static void Graficzna()
        {
            int[] tablica = GenerujLiczby(10);
            int[] wylosowan_liczby = new int[tablica.Length] ;
            tablica.CopyTo(wylosowan_liczby, 0);
            int temp = 0;

            Console.Clear();

            for (int i = 0; i < tablica.Length - 1; i++)
            {
                for (int j = 0; j < tablica.Length - 1; j++)
                {
                    Console.Clear();

                    //Wartość do ustawienia pozycji x kurssora
                    int counter = 3;
                    if (tablica[j] > tablica[j + 1])
                    {
                        temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;

                        //kolor przed zmienianymi liczbami
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        for (int k = 0; k < j; k++)
                        {
                            //rysuj graf
                            GrafBar(tablica[k], counter, 30);
                            counter++;
                        }

                        //kolor zamienianych liczb
                        Console.ForegroundColor = ConsoleColor.Green;
                        GrafBar(tablica[j], counter, 30);
                        counter++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        GrafBar(tablica[j + 1], counter, 30);
                        counter++;

                        //kolor liczb za zamienianymi
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        for (int k = j + 2; k < tablica.Length; k++)
                        {
                            GrafBar(tablica[k], counter, 30);
                            counter++;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
            //posortowane
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < tablica.Length; i++)
            {
                GrafBar(tablica[i], i + 5, 30);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nWylosowane liczby:  ");
            for (int i = 0; i < wylosowan_liczby.Length; i++)
            {
                Console.Write(wylosowan_liczby[i] + " ");
            }
            Console.Write("\nPosortowane liczby: ");
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.Write(tablica[i] + " ");
            }
            Console.WriteLine("\n\nTeraz naciśnij dowolny klawisz");
            Console.ReadKey();
        }

        public static void GrafBar(int wysokosc, int xPos, int yPos)
        {
            bool rownaSie = (wysokosc % 2 == 0) ? rownaSie = true : rownaSie = false;

            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine("_");

            //esli jeden, rysuje 1 bloczek
            if (wysokosc / 2 == 0 && rownaSie == false)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("\u2584");
            }
            while (wysokosc / 2 != 0)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("\u2588");

                if (wysokosc / 2 > 1) wysokosc--;
                wysokosc--;
                //Dodatkowe bloczki
                if (wysokosc / 2 == 0 && rownaSie == false)
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("\u2584");
                }
                yPos = yPos - 1;
            }
            Console.SetCursorPosition(xPos, 31);
        }

        #endregion
        #region Menu Programu
        public static bool Menu()
{
    Console.Clear();
    Console.WriteLine("Witaj w programie przedstawiającym sortowanie bąbelkowe");
    Console.WriteLine("..::MENU::..");
    Console.WriteLine("1 - DEFINICJA ALGORYTMU BĄBELKOWEGO");
    Console.WriteLine("2 - PRZEDSTAWIENIE ALFANUMERYCZNE");
    Console.WriteLine("3 - PRZEDSTAWIENIE GRAFICZNE");
    Console.WriteLine("4 - CZAS SORTOWANIA");
    Console.WriteLine("5 - WYJŚCIE Z PROGRAMU");

            int wybor = int.Parse(Console.ReadLine());

    switch (wybor)
    {
        case 1:
            Definicje();
            break;
        case 2:
             Alfanumeryczna();
            break;
        case 3:
            Graficzna();
            break;
        case 4:
            CzasWykonania();
            break;
        case 5:
            Environment.Exit(0);
            break;
    }
    return false;


}
#endregion

static void Main(string[] args)
{
    

    while (Menu() == false) ;
}
        
        
    }
}