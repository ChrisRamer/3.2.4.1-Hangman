using System;
using System.Collections.Generic;

namespace Hangman.Models
{
	public class HangmanGame
	{
		public static string Sentence { get; set; }
		private static List<string> sentencesToChooseFrom = new List<string>()
		{
			"Brian might be a very cool guy",
			"Coding is immense fun",
			"Programming is like a puzzle game",
		};
		public static List<char> lettersGuessed = new List<char>();
		public static char GuessedLetter { get; set; }
		public static int IncorrectGuesses { get; set; }

		public static string GetSentence()
		{
			if (string.IsNullOrEmpty(Sentence))
			{
				Random random = new Random();
				int randomIndex = random.Next(0, sentencesToChooseFrom.Count - 1);
				Sentence = sentencesToChooseFrom[randomIndex];
				Console.WriteLine("Generated sentence: " + Sentence);
			}

			return MakeSentence();
		}

		private static string MakeSentence()
		{
			string formattedSentence = Sentence.ToUpper();

			foreach (char letter in formattedSentence)
			{
				if (Char.IsLetter(letter) && !lettersGuessed.Contains(letter))
				{
					formattedSentence = formattedSentence.Replace(letter.ToString(), "_ "); // Replace unguessed letters with underscores
				}
			}

			return formattedSentence;
		}

		public static void GuessLetter(char letter)
		{
			GuessedLetter = Char.ToUpper(letter);
			if (!lettersGuessed.Contains(GuessedLetter)) lettersGuessed.Add(GuessedLetter);

			if (!Sentence.Contains(letter) && IncorrectGuesses < 6) IncorrectGuesses++;
		}

		public static void ClearAll()
		{
			lettersGuessed.Clear();
		}
	}
}