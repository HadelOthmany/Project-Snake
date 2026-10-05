namespace Snake
{
    internal static class Program
    {
     
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            GameEngine _engine = new GameEngine();
            _engine.Run();
        }
    }
}