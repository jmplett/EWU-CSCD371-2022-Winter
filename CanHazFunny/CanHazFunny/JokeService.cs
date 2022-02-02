using System.Net.Http;
using System;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            Uri uri = new Uri("https://geek-jokes.sameerkumar.website/api");
            string joke = HttpClient.GetStringAsync(uri).Result;
            return joke;
        }
    }
}
