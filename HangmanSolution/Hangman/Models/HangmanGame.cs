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
			"Chris really is awesome",
			"Daniel is pretty cool too",
			"Hollow Knight is an absolutely incredible game so far",
			"This project was a truly a supercalifragilisticexpialidocious experience",
		};
		public static List<char> lettersGuessed = new List<char>();
		public static char GuessedLetter { get; set; }
		public static int IncorrectGuesses { get; set; }

		public static string GetSentence()
		{
			if (string.IsNullOrEmpty(Sentence))
			{
				Random random = new Random();
				int randomIndex = random.Next(0, sentencesToChooseFrom.Count);
				Sentence = sentencesToChooseFrom[randomIndex];
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
					// Replace unguessed letters with underscores
					formattedSentence = formattedSentence.Replace(letter.ToString(), "_ ");
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

		public static bool DoesSentenceHaveLetter(char letter)
		{
			return Sentence.ToLower().Contains(char.ToLower(letter));
		}

		public static void Reset()
		{
			Sentence = string.Empty;
			lettersGuessed.Clear();
			GuessedLetter = '\0';
			IncorrectGuesses = 0;
		}
	}
}