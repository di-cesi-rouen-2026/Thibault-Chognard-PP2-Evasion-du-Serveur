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

    public static void WriteQuestion(Dictionary<string, object> QuestionsDictionnary)
    {
        List<string> listeReponses = new();
        listeReponses.Add(QuestionsDictionnary["Reponse_Correcte"].ToString());
        listeReponses.Add(QuestionsDictionnary["Reponse_Fausse_1"].ToString());
        listeReponses.Add(QuestionsDictionnary["Reponse_Fausse_2"].ToString());

        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(listeReponses));

        FastWriteLine($"{QuestionsDictionnary["Question"]}\n");

        foreach(string reponse in listeReponses)
        {
            int index = listeReponses.IndexOf(reponse);
            FastWriteLine($"{index}. {reponse}\n");
        }
    }
}