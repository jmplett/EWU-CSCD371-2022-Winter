using System;
namespace CanHazFunny
{
	public class Jester
	{
		private JokeService _JokeService;
		private WriteLine _WriteLine;
			
		public Jester(JokeService? jokeService, WriteLine? output)
		{
			if(jokeService == null)
				throw new ArgumentNullException(nameof(jokeService));

			if(output == null)	
				throw new ArgumentNullException(nameof(output));

			_JokeService = jokeService;
			_WriteLine = output;
		}

		public void TellJoke()
        {
			string joke = _JokeService.GetJoke();

			while (joke.Contains("Chuck Norris"))
			{
				joke = _JokeService.GetJoke();
			}

			_WriteLine.PrintToConsole(joke);
        }
	}
}

