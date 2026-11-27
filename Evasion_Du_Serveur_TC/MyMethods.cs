namespace Evasion_Du_Serveur_TC;

using System.Runtime.InteropServices;

public class MyMethods
{
    public static Random rand = new Random();
    public static void AttendreContinuer()
    {
        Console.WriteLine();
        Console.Write("Appuyer sur Entrée pour continuer");
        Console.ReadLine();
        Console.Clear();
    }

    public static void RegularWriteLine(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (i<message.Length-1)
            {
                Console.Write(message[i]);
            }
            else
            {
                Console.WriteLine(message[i]);
            }
            Thread.Sleep(1);
        }
        
    }
    public static void FastWriteLine(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (i<message.Length-1)
            {
                Console.Write(message[i]);
            }
            else
            {
                Console.WriteLine(message[i]);
            }

            if (i%2==0)
            {
                Thread.Sleep(1);
            }
            
        }
        
    }
    public static void SlowWriteLine(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (i<message.Length-1)
            {
                Console.Write(message[i]);
            }
            else
            {
                Console.WriteLine(message[i]);
            }
            Thread.Sleep(15);
            
            
        }
        
    }
    public static void WriteMenu(Dictionary<string, string> menuItems)
    {
        foreach (var kvp in menuItems)
        {
            MyMethods.FastWriteLine($"{kvp.Key}. {kvp.Value}\n");
        }
    }

    public static bool ChangerIntEnBool(int nombre)
    {
        if(nombre == 0)
        {
            return false;
        }
        else if(nombre == 1)
        {
            return true;
        }
        else
        {
            throw new ArgumentException($"Cannot cast {nombre} as a boolean !");
        }
    }

    public static void HandleQuestion(Dictionary<string, object> questionsDictionnary)
    {
        List<string> listeReponses = new();
        listeReponses.Add(questionsDictionnary["Reponse_Correcte"].ToString());
        listeReponses.Add(questionsDictionnary["Reponse_Fausse_1"].ToString());
        listeReponses.Add(questionsDictionnary["Reponse_Fausse_2"].ToString());

        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(listeReponses));

        FastWriteLine($"{questionsDictionnary["Question"]}\n");
        Dictionary<int, string> indexOfAnswer = new();
        foreach (string reponse in listeReponses)
        {
            int index = listeReponses.IndexOf(reponse);
            FastWriteLine($"{index+1}. {reponse}\n");
            indexOfAnswer[index+1] = reponse;
        }

        Console.WriteLine("Faite votre choix.");
        string choixQuestion = Console.ReadLine();
        while (choixQuestion!="1" && choixQuestion!="2" && choixQuestion != "3")
        {
            Console.WriteLine("INPUT ERROR");
            Console.WriteLine("Tapez 1, 2 ou 3");
            choixQuestion = Console.ReadLine();
        }
        if (indexOfAnswer[int.Parse(choixQuestion)] == questionsDictionnary["Reponse_Correcte"].ToString())
        {

        }
        else
        {
            PrendreDegat();
        }
    }

    public static int ModifierPV(int modification)
    {
        GlobalVariable.pvRestant += modification;
        return GlobalVariable.pvRestant;
    }
    public static void ImprimerPV()
    {
        if (!GlobalVariable.dejaPerduPV)
        {
            Console.WriteLine("\n");
            return;
        }
        string coeurEntier = "♥";
        string coeurBrise = "✕";

        for(int i = 0; i < GlobalVariable.pvRestant; i++)
        {
            Console.Write(coeurEntier + " ");
        }
        for(int i = 0; i < 3-GlobalVariable.pvRestant; i++)
        {
            Console.Write(coeurBrise + " ");
        }
        Console.WriteLine("\n");
    }

    public static void PrendreDegat()
    {
        if (!GlobalVariable.dejaPerduPV)
        {
            GlobalVariable.dejaPerduPV = true;
            Console.Clear();
            MyMethods.RegularWriteLine(StoryText.Get("PrendreDegat1", GlobalVariable.heroName));
            AttendreContinuer();
        }
        else if (GlobalVariable.pvRestant >1)
        {
            Console.Clear();
            MyMethods.RegularWriteLine(StoryText.Get("PrendreDegat2", GlobalVariable.heroName));
            AttendreContinuer();
        }
        else
        {
            Console.Clear();
            MyMethods.RegularWriteLine(StoryText.Get("PrendreDegat3", GlobalVariable.heroName));
            AttendreContinuer();
        }
        ModifierPV(-1);
        if(GlobalVariable.pvRestant <= 0)
        {
            DefaiteHero();
        }
    }

    public static void DefaiteHero()
    {
        if (GlobalVariable.dansSalle1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            MyMethods.FastWriteLine(StoryText.Get("Défaite1", GlobalVariable.heroName));
            AttendreContinuer();
            MyMethods.SlowWriteLine(StoryText.Get("Défaite1.1", GlobalVariable.heroName));
            AttendreContinuer();
            Environment.Exit(0);
        }
    }
}