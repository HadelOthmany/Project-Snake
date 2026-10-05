namespace Snake
{
    public class RandomSpeedBoosterFood : AbstractFood
    {
        private int speedMultiplier;
        private int durationInSeconds;
        private GameEngine engine;

        public RandomSpeedBoosterFood(int x, int y, GameEngine gameEngine)
         : base(x, y, gameEngine)
        {
            Random random = new Random();
            int randomMultiplier = random.Next(1,4);
            engine = gameEngine;
            speedMultiplier = randomMultiplier;
            durationInSeconds = 10;
        }

        public override void OnConsume(Snake snake)
        {
            engine.IncreaseSpeedOfRandomSnake(speedMultiplier, durationInSeconds);
            engine.RemoveFood(this);
        }
    }
}
