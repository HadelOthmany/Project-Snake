using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class MovementHandler
    {
        public static void HandleMovement(KeyEventArgs key, Snake snake)
        {
            if (key == null)
            {
                snake.SetDirection(Direction.Right);
                return;
            }

            if (snake.ID == 1)
            {
                if (key.KeyCode == Keys.W && snake.GetDirection() != Direction.Down)
                    snake.SetDirection(Direction.Up);
                else if (key.KeyCode == Keys.S && snake.GetDirection() != Direction.Up)
                    snake.SetDirection(Direction.Down);
                else if (key.KeyCode == Keys.A && snake.GetDirection() != Direction.Right)
                    snake.SetDirection(Direction.Left);
                else if (key.KeyCode == Keys.D && snake.GetDirection() != Direction.Left)
                    snake.SetDirection(Direction.Right);
            }
            else if (snake.ID == 2)
            {
                if (key.KeyCode == Keys.Up && snake.GetDirection() != Direction.Down)
                    snake.SetDirection(Direction.Up);
                else if (key.KeyCode == Keys.Down && snake.GetDirection() != Direction.Up)
                    snake.SetDirection(Direction.Down);
                else if (key.KeyCode == Keys.Left && snake.GetDirection() != Direction.Right)
                    snake.SetDirection(Direction.Left);
                else if (key.KeyCode == Keys.Right && snake.GetDirection() != Direction.Left)
                    snake.SetDirection(Direction.Right);
            }
            else if (snake.ID == 3)
            {
                if (key.KeyCode == Keys.I && snake.GetDirection() != Direction.Down)
                    snake.SetDirection(Direction.Up);
                else if (key.KeyCode == Keys.K && snake.GetDirection() != Direction.Up)
                    snake.SetDirection(Direction.Down);
                else if (key.KeyCode == Keys.J && snake.GetDirection() != Direction.Right)
                    snake.SetDirection(Direction.Left);
                else if (key.KeyCode == Keys.L && snake.GetDirection() != Direction.Left)
                    snake.SetDirection(Direction.Right);
            }
        }

    }

}
