using System;

public class HangMan
{
    int chances = 3;
    string word;

    public HangMan(string[] wordlist)
    {
        Random Choice = new Random();
        int random_index = Choice.Next(0, wordlist.Length);
        this.word = wordlist[random_index];
    }

    public void Start()
    {
        string wordTrack;

        string[] wordTrackArray = new string[this.word.Length];

        char[] wordCharArray = word.ToCharArray();

        string finalWord = String.Join(" ", wordCharArray);

        for (int i = 0; i < wordCharArray.Length; i++)
        {
            wordTrackArray[i] = "-";
        }

        wordTrack = String.Join(" ", wordTrackArray);

        Console.WriteLine("WELCOME TO HANGMAN GAME");
        Console.WriteLine("YOU HAVE " + this.chances + " CHANCES(S), GOODLUCK");
        Console.WriteLine("START GUESSING\n");
        Console.WriteLine(wordTrack);

        while (this.chances > 0)
        {
            if (finalWord == wordTrack)
            {
                Console.WriteLine("CONGRATULATIONS YOU HAVE COMPLETED THE WORD");
                break;
            }
            Console.Write("ENTER A LETTER: ");
            string? userInput = Console.ReadLine();

            if (word.Contains(userInput!))
            {

                if (wordTrackArray.Contains(userInput))
                {
                    Console.WriteLine("You have already entered ".ToUpper() + userInput);
                    Console.WriteLine(wordTrack);
                }
                else
                {
                    for (int i = 0; i < wordCharArray.Length; i++)
                    {
                        if (Convert.ToString(wordCharArray[i]) == userInput)
                        {
                            wordTrackArray[i] = userInput;
                        }
                    }
                }

                wordTrack = String.Join(" ", wordTrackArray);
                Console.WriteLine(wordTrack);
            }

            else
            {
                this.chances--;
                if (this.chances == 0)
                {
                    Console.WriteLine("GAMEOVER");
                }
                Console.WriteLine($"You have {chances} chance(s) left".ToUpper());
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        string[] fruits = { "apple", "mango" };

        HangMan Game = new HangMan(fruits);
        Game.Start();
    }
}