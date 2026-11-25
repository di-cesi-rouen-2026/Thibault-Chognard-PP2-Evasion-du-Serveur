namespace EscapeGameTC;

using System.Runtime.InteropServices;

public class TextMethods
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
            TextMethods.FastWriteLine($"{kvp.Key}. {kvp.Value}\n");
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
            FastWriteLine($"{index}. {reponse}\n");
            indexOfAnswer[index] = reponse;
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

        }
    }

    public static void ImprimerPV(int pvRestant,bool dejaPerduPV)
    {
        if (!dejaPerduPV)
        {
            Console.WriteLine("");
            return;
        }
        string coeurEntier = "💚";
        string coeurBrise = "❎";

        for(int i = 0; i < pvRestant; i++)
        {
            Console.Write(coeurEntier);
        }
        for(int i = 0; i < 3-pvRestant; i++)
        {
            Console.Write(coeurBrise);
        }
        Console.WriteLine("\n");
    }

}