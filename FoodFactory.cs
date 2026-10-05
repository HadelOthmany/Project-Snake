using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake
{
    public static class FoodFactory
    {
        public static AbstractFood GenerateRandomFood(int x, int y, GameEngine engine)
        {
            Random random = new Random();
            int type = random.Next(0, 4);

            AbstractFood food = null;
            switch (type)
            {
                case 0:
                    food = new StandardFood(x, y, engine);
                    food.Brush = new SolidBrush(Color.Red);
                    break;
                case 1:
                    food = new ValuableFood(x, y, engine);
                    food.Brush = new SolidBrush(Color.Blue);
                    break;
                case 2:
                    food = new DietFood(x, y, engine);
                    food.Brush = new SolidBrush(Color.Yellow);
                    break;
                default:
                    food = new RandomSpeedBoosterFood(x, y, engine);
                    food.Brush = new SolidBrush(Color.Green);
                    break;
            }

            return food;
        }
    }
}
