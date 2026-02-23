using System.Text.Json;
using Konyv;

namespace Konyv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = File.ReadAllText("konyvek.json");
                Gyoker gy = JsonSerializer.Deserialize<Gyoker>(file);

                Console.WriteLine("1. Feladat - Ifjúsági regények:");
                foreach (var konyv in gy.konyvtar)
                {
                    foreach (var kategoria in konyv.kategoriak)
                    {
                        if (kategoria.ToLower().Contains("ifjúsági"))
                        {
                            Console.WriteLine(konyv);
                            break;
                        }
                    }
                }
                Console.WriteLine();

                Console.WriteLine("2. Feladat - Ár szerint rendezve:");
                Konyv maxAr = gy.konyvtar[0];
                for (int i = 1; i < gy.konyvtar.Count; i++)
                {
                    if (gy.konyvtar[i].ar > maxAr.ar)
                    {
                        maxAr = gy.konyvtar[i];
                    }
                }
                for (int i = 0; i < gy.konyvtar.Count - 1; i++)
                {
                    for (int j = 0; j < gy.konyvtar.Count - 1 - i; j++)
                    {
                        if (gy.konyvtar[j].ar < gy.konyvtar[j + 1].ar)
                        {
                            Konyv csere = gy.konyvtar[j];
                            gy.konyvtar[j] = gy.konyvtar[j + 1];
                            gy.konyvtar[j + 1] = csere;
                        }
                    }
                }
                foreach (var konyv in gy.konyvtar)
                {
                    Console.WriteLine($"{konyv.cim} - {konyv.ar} Ft");
                }
                Console.WriteLine();

                Console.WriteLine("3. Feladat - Csoportosítás oldalszám szerint:");
                int csoport = 0;
                for (int i = 0; i < gy.konyvtar.Count; i++)
                {
                    int ujCsoport = (gy.konyvtar[i].oldalszam - 1) / 100;
                    if (ujCsoport != csoport)
                    {
                        csoport = ujCsoport;
                        int minOldal = csoport * 100 + 1;
                        int maxOldal = (csoport + 1) * 100;
                        Console.WriteLine($"{minOldal}-{maxOldal} oldal között:");
                    }
                    Console.WriteLine($"  {gy.konyvtar[i].cim} ({gy.konyvtar[i].oldalszam} oldal)");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Json fájl feldolgozási hiba: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Könyvtári hiba: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Fájl elérési hiba: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fájlkezelési hiba: " + ex.Message);
            }
        }
    }
}
