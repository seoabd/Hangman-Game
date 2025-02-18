using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text.Unicode;

namespace Hangman

{
    class Wordreverse
    {
        
        private static void Main(string[] args)
        {

            const int MAXIMUM_GUESSES = 6;

            Console.WriteLine("--------------------------------");
            Console.WriteLine("- Welcome to the Hangman Game! -");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please try to guess the word :)\n");

            List<string> aListOfWords = new List<string>(){"Elon", "Toyota", "Apple", "Mercedes", "Microsoft", "Rakete"};
            Random rng = new Random();
            
            string randomString = aListOfWords[rng.Next(aListOfWords.Count)];
            string RandomWord = randomString;
            
            
            char [] hiddenWord = new char [RandomWord.Length]; 
            
            for (int i = 0; i < hiddenWord.Length; i++) // to loop in everysingle index of the Random word to convert the word into underscore lines!
            {
                hiddenWord[i] = '_';
                Console.Write(hiddenWord[i]);
            }
            
            Console.WriteLine();
            Console.WriteLine(randomString);
            
            int guessesRemaining = MAXIMUM_GUESSES;
            int numberOfGuesses = 0;
            Console.WriteLine($"You have {guessesRemaining} guesses remaining. Chose wisely:)");
            
            while (numberOfGuesses <= MAXIMUM_GUESSES)
            {
                Console.Write("\nPlease enter a single letter you wanna guess: ");
                string userInput = Console.ReadLine().ToLower();
                
                if (string.IsNullOrEmpty(userInput) || userInput.Length != 1 || userInput.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                char guessedChar = userInput[0];
                
                for (int i = 0; i < RandomWord.Length; i++)
                {
                    if (char.ToLower(RandomWord[i]) == guessedChar)
                    {
                        hiddenWord[i] = RandomWord[i]; // it replaces the index of the underlinescore with the letter in given from the input
                    }
                }

                if(RandomWord.Contains(guessedChar))
                {
                    Console.WriteLine("\nYou guessed the correct letter or letters! Please continue .....");
                }
                else
                {
                    numberOfGuesses++;
                    guessesRemaining--;
                    Console.WriteLine("\nYou guessed the wrong letter! Please try again...");
                }
                Console.WriteLine($"You have {guessesRemaining} guesses left.\n");
                Console.Write(hiddenWord);
                
              
                string guessedWord = new string(hiddenWord); 

                if (guessedWord == RandomWord)
                {
                    Console.WriteLine("\nCongratulations....You won the Hangman-game!");
                    break;
                }

                if (numberOfGuesses > MAXIMUM_GUESSES)
                {
                    Console.WriteLine($"\nYou lost the game! The random Word was: {RandomWord}!");
                }
            }
        }
    }
}    
