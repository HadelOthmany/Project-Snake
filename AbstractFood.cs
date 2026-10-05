using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    public abstract class AbstractFood
    {
        #region Properties

        public int Points { get; protected set; }
        public int LengthIncrease { get; protected set; }
        public SolidBrush Brush { get; set; }

        #endregion

        #region fields

        private Rectangle foodRectangle;
        private GameEngine gameEngine;

        #endregion

        #region Constructor

        public AbstractFood(int x, int y, GameEngine engine)
        {
            gameEngine = engine;
            foodRectangle = new Rectangle(x, y, gameEngine.ObjectSize - 1, gameEngine.ObjectSize - 1);
        }

        #endregion

        #region Public methods

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brush, foodRectangle);
            ControlPaint.DrawBorder(graphics, foodRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public bool Intersects(Snake snake)
        {
            var headPosition = snake.GetBodyCoordinates().First();
            bool isWithinXRange = headPosition.X - gameEngine.ObjectSize <= foodRectangle.X && foodRectangle.X <= headPosition.X + gameEngine.ObjectSize;
            bool isWithinYRange = headPosition.Y - gameEngine.ObjectSize <= foodRectangle.Y && foodRectangle.Y <= headPosition.Y + gameEngine.ObjectSize;

            return isWithinXRange && isWithinYRange;
        }

        public abstract void OnConsume(Snake snake);

        #endregion
    }
}
