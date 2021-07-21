using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_4
{
    class Program
    {
        public interface IFigura
        {
            double pole { get; }
            double obwod { get; }
            double Powieksz();
            double Pomniejsz();
        }
        public class Kwadrat : IFigura
        {
            private double _Z;
            public Kwadrat(double z)
            {
                _Z = z;
            }
            public Kwadrat()
            {
                Random random = new Random();
                _Z = random.Next(1, 100);
            }
            public double pole
            {
                get { return _Z * _Z; }
            }
            public double obwod
            {
                get { return 4 * _Z; }
            }
            public override string ToString()
            {
                return "Kwadrat: " + _Z + "\nPole wynosi: " + pole + "\nObwód wynosi: " + obwod;
            }
            public double Powieksz()
            {
                _Z = _Z * 2;
                return 1;
            }
            public double Pomniejsz()
            {
                _Z = _Z / 2;
                return 1;
            }
        }
        public class Prostokat : IFigura
        {
            private double _X, _Z;
            public Prostokat(double x, double z)
            {
                _X = x;
                _Z = z;
            }
            public Prostokat()
            {
                Random random = new Random();
                _X = random.Next(1, 100);
                _Z = random.Next(1, 100);
            }
            public double pole
            {
                get { return _X * _Z; }
            }
            public double obwod
            {
                get { return 2 * _X + 2 * _Z; }
            }

            public override string ToString()
            {
                return "Prostokąt: " + _X + " x " + _Z + "\nPole wynosi: " + pole + "\nObwód wynosi: " + obwod;
            }
            public double Powieksz()
            {
                _X = _X * 2;
                _Z = _Z * 2;
                return 1;
            }
            public double Pomniejsz()
            {
                _X = _X / 2;
                _Z = _Z / 2;
                return 1;
            }
        }
        public class Kolo : IFigura
        {
            private double _R;
            public Kolo(double r)
            {
                _R = r;
            }
            public Kolo()
            {
                Random random = new Random();
                _R = random.Next(1, 100);
            }
            public double pole
            {
                get { return _R * _R; }
            }
            public double obwod
            {
                get { return 2 * _R; }
            }
            public override string ToString()
            {
                return "Koło: " + _R + "\nPole wynosi: " + pole + "\nObwód wynosi: " + obwod;
            }
            public double Powieksz()
            {
                _R = _R * 2;
                return 1;
            }
            public double Pomniejsz()
            {
                _R = _R / 2;
                return 1;
            }
        }
        abstract class FiguraFabryka
        {
            public abstract IFigura Utworz();
        }
        class KwadratFabryka : FiguraFabryka
        {
            public override IFigura Utworz()
            {
                return new Kwadrat();
            }
            public IFigura UtworzZPodanychWartosci(double pwartosc)
            {
                return new Kwadrat(pwartosc);
            }
        }
        class ProstokatFabryka : FiguraFabryka
        {
            public override IFigura Utworz()
            {
                return new Prostokat();
            }
            public IFigura UtworzZPodanychWartosci(double pwartosc, double dwartosc)
            {
                return new Prostokat(pwartosc, dwartosc);
            }
        }
        class KoloFabryka : FiguraFabryka
        {
            public override IFigura Utworz()
            {
                return new Kolo();
            }
            public IFigura UtworzZPodanychWartosci(double pwartosc)
            {
                return new Kolo(pwartosc);
            }
        }
        public class Figura
        {
            IDictionary slownik = new Dictionary<String, int> { { "Kwadrat", 1 }, { "Prostokąt", 2 }, { "Koło", 3 }, { "MójKwadrat", 4 }, { "MójProstokąt", 5 }, { "MojeKoło", 6 } };
            KwadratFabryka kwadratFabryka;
            ProstokatFabryka prostokatFabryka;
            KoloFabryka koloFabryka;
            public Figura()
            {
                kwadratFabryka = new KwadratFabryka();
                prostokatFabryka = new ProstokatFabryka();
                koloFabryka = new KoloFabryka();
            }

            public IFigura ZabierzZeSlownika(String slownikfigura)
            {
                switch (slownik[slownikfigura])
                {
                    case 1:
                        return kwadratFabryka.Utworz();
                    case 2:
                        return prostokatFabryka.Utworz();
                    case 3:
                        return koloFabryka.Utworz();
                    default:
                        throw new ArgumentException();
                }
            }
            public IFigura StworzWlasny(String slownikfigura, double x, double y)
            {
                switch(slownik[slownikfigura])
                {
                    case 4:
                        return kwadratFabryka.UtworzZPodanychWartosci(x);
                    case 5:
                        return prostokatFabryka.UtworzZPodanychWartosci(x, y);
                    case 6:
                        return koloFabryka.UtworzZPodanychWartosci(x);
                    default:
                        throw new ArgumentException();
                }
                
            }
        }
        static void Main(string[] args)
        {
            int program = 1;
            do
            {
                Console.WriteLine("Wciśnij jeden z podanych poniżej przycisków: \n1 - Program liczący pole i obwód dla figur KWADRAT, PROSTOKĄT, KOŁO.\n2 - Fabryka tworząca figury.\nInny przycisk (oprócz przycisku POWER) - Wyjdź z programu.");
                var przycisk = Console.ReadKey();
                Console.Clear();
                switch (przycisk.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        IFigura[] a = new IFigura[3];
                        int i = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    Console.WriteLine("Podaj długość boku kwadratu.");
                                    a[j] = new Kwadrat(Convert.ToDouble(Console.ReadLine()));
                                    break;
                                case 1:
                                    Console.WriteLine("Podaj długość boków prostokąt.");
                                    a[j] = new Prostokat(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                                    break;
                                case 2:
                                    Console.WriteLine("Podaj długość promienia koła.");
                                    a[j] = new Kolo(Convert.ToDouble(Console.ReadLine()));
                                    break;
                            }

                            Console.WriteLine(a[j].ToString());

                            if (j == 2)
                            {
                                Console.WriteLine("\nAby powiększyć lub pomniejszyć podane wartości naciśnij:\n 1 - Aby powiększyć boki 2-krotnie\n 2 - Aby pomniejszyć boki 2-krotnie.\n 3 - Aby wyjść do menu.");
                            }
                            else
                            {
                                Console.WriteLine("\nAby powiększyć lub pomniejszyć podane wartości naciśnij:\n 1 - Aby powiększyć boki 2-krotnie\n 2 - Aby pomniejszyć boki 2-krotnie.\n 3 - Aby wybrać kolejną figurę.");
                            }

                            i = 0;
                            while (i == 0)
                            {
                                przycisk = Console.ReadKey();
                                switch (przycisk.Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        Console.Clear();
                                        a[j].Powieksz();
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        Console.Clear();
                                        a[j].Pomniejsz();
                                        break;
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
                                        i = 1;
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }

                                Console.WriteLine(a[j].ToString());

                                if (j == 2)
                                {
                                    Console.WriteLine("\nAby powiększyć lub pomniejszyć podane wartości naciśnij:\n 1 - Aby powiększyć boki 2-krotnie.\n 2 - Aby pomniejszyć boki 2-krotnie.\n 3 - Aby wyjść do menu.");
                                }
                                else
                                {
                                    Console.WriteLine("\nAby powiększyć lub pomniejszyć podane wartości naciśnij:\n 1 - Aby powiększyć boki 2-krotnie.\n 2 - Aby pomniejszyć boki 2-krotnie.\n 3 - Aby wybrać kolejną figurę.");
                                }
                            }
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        int fabryka = 1;
                        Figura figura = new Figura();
                        List<IFigura> list = new List<IFigura>();
                        IDictionary slow = new Dictionary<int, String> { { 1, "Kwadrat" }, { 2, "Prostokąt" }, { 3, "Koło" }, { 4, "MójKwadrat" }, { 5, "MójProstokąt" }, { 6, "MojeKoło" } };
                        Random random = new Random();

                        Console.WriteLine("Podaj ilość losowych figur:");
                        int losowefigury = Convert.ToInt32(Console.ReadLine());

                        for (int p = 0; p < losowefigury; p++)
                        {
                            switch (random.Next(1, 4))
                            {
                                case 1:
                                    list.Add(figura.ZabierzZeSlownika("Kwadrat"));
                                    break;
                                case 2:
                                    list.Add(figura.ZabierzZeSlownika("Prostokąt"));
                                    break;
                                case 3:
                                    list.Add(figura.ZabierzZeSlownika("Koło"));
                                    break;
                                }
                        }
                        do
                            { 
                            Console.WriteLine("Wciśnij jeden z podanych poniżej przycisków: \n1 - Wyświetl listę figur.\n2 - Wyświetl wybraną figurę.\n3 - Usuń figurę.\n4 - Dodaj figurę.\n5 - Powiększ wybraną figurę.\n6 - Pomniejsz wybraną figurę.\nInny przycisk (oprócz przycisku POWER) - Przejdź do poprzedniego menu.");
                            var menu = Console.ReadKey();
                            int index = list.Count, liczba;
                            switch (menu.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Console.Clear();
                                    foreach (IFigura numerlisty in list)
                                    {                      
                                        Console.WriteLine(list.IndexOf(numerlisty) + ": " + numerlisty.ToString());
                                    }
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.WriteLine("\nWprowadź numer figury");
                                    liczba = Convert.ToInt32(Console.ReadLine());
                                    if (liczba < list.Count && liczba > 0)
                                        Console.WriteLine(list[liczba].ToString());
                                    break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    Console.WriteLine("\nWprowadź numer figury");
                                    liczba = Convert.ToInt32(Console.ReadLine());
                                    if (liczba < list.Count && liczba > 0)
                                        list.RemoveAt(liczba);
                                    break;
                                case ConsoleKey.D4:
                                case ConsoleKey.NumPad4:
                                    Console.WriteLine("\nChcesz dodać losową figurę? Czy z podanych przez Ciebie wartości?\n1 - Chcę stworzyć losową figurę.\n2 - Chcę stworzyć figurę z podanych przeze mnie wartości.");
                                    var wybor = Console.ReadKey();
                                    switch (wybor.Key)
                                    {
                                        case ConsoleKey.D1:
                                        case ConsoleKey.NumPad1:
                                            list.Add(figura.ZabierzZeSlownika((String)slow[random.Next(1, 3)]));
                                            break;
                                        case ConsoleKey.D2:
                                        case ConsoleKey.NumPad2:
                                            Console.WriteLine("\nWybierz jeden z podanych poniżej przycisków:\n1 - Kwadrat.\n2 - Prostokąt.\n3 - Koło.");
                                            wybor = Console.ReadKey();
                                            double x, y;
                                            switch (wybor.Key)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.WriteLine("Podaj długość boku kwadratu.");
                                                    x = Convert.ToDouble(Console.ReadLine());
                                                    y = 0;
                                                    list.Add(figura.StworzWlasny((String)slow[4], x, y));
                                                    break;
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.WriteLine("Podaj długość boków prostokąt.");
                                                    x = Convert.ToDouble(Console.ReadLine());
                                                    y = Convert.ToDouble(Console.ReadLine());
                                                    list.Add(figura.StworzWlasny((String)slow[5], x, y));
                                                    break;
                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.WriteLine("Podaj długość promienia koła.");
                                                    x = Convert.ToDouble(Console.ReadLine());
                                                    y = 0;
                                                    list.Add(figura.StworzWlasny((String)slow[6], x, y));
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case ConsoleKey.D5:
                                case ConsoleKey.NumPad5:
                                    Console.WriteLine("Wprowadź numer figury");
                                    liczba = Convert.ToInt32(Console.ReadLine());
                                    if (liczba < list.Count && liczba > 0)
                                        list[liczba].Powieksz();
                                    break;
                                case ConsoleKey.D6:
                                case ConsoleKey.NumPad6:
                                    Console.WriteLine("Wprowadź numer figury");
                                    liczba = Convert.ToInt32(Console.ReadLine());
                                    if (liczba < list.Count && liczba > 0)
                                        list[liczba].Pomniejsz();
                                    break;
                                default:
                                    fabryka = 0;
                                    break;
                            }
                        } while (fabryka == 1);
                        break;
                    default:
                        program = 0;
                        break;
                }
            } while (program == 1);
        }
    }
}
