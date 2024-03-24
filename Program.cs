using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Calea către fișierul de intrare
        string filePath = "cuvinte.txt";

        // Verificăm dacă fișierul există
        if (File.Exists(filePath))
        {
            // Citim textul din fișier
            string text = File.ReadAllText(filePath);

            // Separăm textul în cuvinte folosind spațiul ca separator
            string[] cuvinte = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Declaram un tablou bidimensional pentru a stoca cuvintele pentru fiecare literă
            string[][] cuvinteGrupate = new string[26][];

            // Iterăm prin fiecare cuvânt și le grupăm în funcție de prima literă
            foreach (string cuvant in cuvinte)
            {
                char primaLitera = Char.ToLower(cuvant[0]);
                int index = primaLitera - 'a';

                if (index >= 0 && index < 26)
                {
                    if (cuvinteGrupate[index] == null)
                    {
                        cuvinteGrupate[index] = new string[] { cuvant };
                    }
                    else
                    {
                        Array.Resize(ref cuvinteGrupate[index], cuvinteGrupate[index].Length + 1);
                        cuvinteGrupate[index][cuvinteGrupate[index].Length - 1] = cuvant;
                    }
                }
            }

            // Afisam tabloul obtinut
            for (int i = 0; i < cuvinteGrupate.Length; i++)
            {
                // Verificăm dacă există cuvinte care încep cu litera corespunzătoare
                if (cuvinteGrupate[i] != null)
                {
                    // Afisam litera corespunzătoare și cuvintele asociate
                    char litera = (char)('a' + i);
                    Console.WriteLine($"Cuvintele care încep cu litera '{litera}':");
                    foreach (string cuvant in cuvinteGrupate[i])
                    {
                        Console.Write(cuvant+" ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                }
            }
        }
        else
        {
            Console.WriteLine("Fișierul nu există.");
        }
    Console.ReadKey();
   }

    // Metoda care filtrează cuvintele care încep cu o anumită literă
    static string[] FiltrareCuvinte(string[] cuvinte, char litera)
    {
        // Declaram o lista pentru a stoca cuvintele care încep cu litera specificată
        var cuvinteFiltrate = new System.Collections.Generic.List<string>();

        // Iterăm prin fiecare cuvânt și verificăm dacă începe cu litera specificată
        foreach (string cuvant in cuvinte)
        {
            if (!string.IsNullOrEmpty(cuvant) && Char.ToLower(cuvant[0]) == litera)
            {
                // Adăugăm cuvântul în lista filtrată
                cuvinteFiltrate.Add(cuvant);
            }
        }

        // Convertim lista într-un tablou și returnam rezultatul
        return cuvinteFiltrate.ToArray();
    }
}
