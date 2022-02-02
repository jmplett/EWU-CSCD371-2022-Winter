namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            new Jester(new JokeService(), new WriteLine()).TellJoke();

        }
    }
}
