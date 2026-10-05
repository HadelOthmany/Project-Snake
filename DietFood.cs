namespace Snake
{
    public class DietFood : AbstractFood
    {
        private GameEngine engine;

        public DietFood(int x, int y, GameEngine gameEngine)
         : base(x, y, gameEngine)
        {
            engine = gameEngine;
            Points = 1;
            LengthIncrease = -1;
        }

        public override void OnConsume(Snake snake)
        {
            snake.UpdatePoints(Points, LengthIncrease);
            engine.RemoveFood(this);

        }
    }
}
