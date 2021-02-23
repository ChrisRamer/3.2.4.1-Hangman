using Microsoft.AspNetCore.Mvc;
using Hangman.Models;

namespace Hangman.Controllers
{
	public class HangmanController : Controller
	{
		[HttpGet("/hangman")]
		public ActionResult Index()
		{
			return View(HangmanGame.lettersGuessed);
		}

		[HttpGet("/hangman/new")]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost("/hangman")]
		public ActionResult Create(char letter)
		{
			HangmanGame.GuessLetter(letter);
			return RedirectToAction("Index");
		}
	}
}