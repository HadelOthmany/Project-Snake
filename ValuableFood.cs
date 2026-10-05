namespace Snake
{
    public class ValuableFood : AbstractFood
    {
        private GameEngine engine;

        public ValuableFood(int x, int y, GameEngine gameEngine)
         : base(x, y, gameEngine)
        {
            engine = gameEngine;
            Points = 5;
            LengthIncrease = 2;
        }

        public override void OnConsume(Snake snake)
        {
            snake.UpdatePoints(Points, LengthIncrease);
            engine.RemoveFood(this);
        }
    }
}
