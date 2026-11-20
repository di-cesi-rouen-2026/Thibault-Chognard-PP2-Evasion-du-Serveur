namespace EscapeGameTC;

public class TextMethods
{
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
        
    }public static void SlowWriteLine(string message)
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


}