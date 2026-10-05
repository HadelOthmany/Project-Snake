namespace Snake
{
    public class StandardFood : AbstractFood
    {
        private GameEngine engine;

        public StandardFood(int x, int y, GameEngine gameEngine)
         : base(x, y, gameEngine)
        {
            engine = gameEngine;
            Points = 1;
            LengthIncrease = 1;
        }

        public override void OnConsume(Snake snake)
        {
            snake.UpdatePoints(Points, LengthIncrease);
            engine.RemoveFood(this);
        }
    }
}
