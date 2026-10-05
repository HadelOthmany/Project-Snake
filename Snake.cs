using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class Snake
    {
        #region

        public int ID { get; private set; }
        public int Speed { get; private set; }
        public int Points { get; private set; }

        #endregion

        #region private fields

        private Direction currentDirection;
        private SolidBrush brush;
        private List<Coordinate> bodyCoordinates;
        private int pendingBodyParts;
        private GameEngine gameEngine;
        private int baseSpeed = 1;
        private int originalSpeed;
        private bool isSpeedBoosted;
        private DateTime speedBoostEndTime;
        private System.Windows.Forms.Timer speedBoostTimer;
        private int speedBoostCounter;

        #endregion

        #region Constructor

        public Snake(int length, Coordinate startPosition, int playerId, GameEngine engine)
        {
            gameEngine = engine;
            bodyCoordinates = new List<Coordinate>();
            currentDirection = Direction.Up;
            ID = playerId;
            brush = new SolidBrush(GetColorById(playerId));
            Speed = baseSpeed;
            InitializeBody(length, startPosition);

            speedBoostTimer = new System.Windows.Forms.Timer();
            speedBoostTimer.Interval = 1000;
            speedBoostTimer.Tick += (sender, e) => { if (speedBoostCounter > 0) speedBoostCounter--; };
        }

        #endregion

        #region Public methods

        public void Draw(Graphics graphics)
        {
            foreach (var coordinate in new List<Coordinate>(bodyCoordinates))
                graphics.FillRectangle(brush, new Rectangle(coordinate.X, coordinate.Y, gameEngine.ObjectSize, gameEngine.ObjectSize));
        }
        public void Move(int boardWidth, int boardHeight)
        {
            int x = bodyCoordinates[0].X;
            int y = bodyCoordinates[0].Y;

            if (currentDirection == Direction.Up)
                y -= gameEngine.ObjectSize;
            else if (currentDirection == Direction.Down)
                y += gameEngine.ObjectSize;
            else if (currentDirection == Direction.Left)
                x -= gameEngine.ObjectSize;
            else if (currentDirection == Direction.Right)
                x += gameEngine.ObjectSize;

            Coordinate newHeadPosition = new Coordinate(x, y);
            bodyCoordinates.Insert(0, newHeadPosition);

            if (pendingBodyParts == 0)
                bodyCoordinates.RemoveAt(bodyCoordinates.Count - 1);
            else if (pendingBodyParts < 0)
            {
                pendingBodyParts++;
                bodyCoordinates.RemoveAt(bodyCoordinates.Count - 1);
            }
            else
            {
                pendingBodyParts--;
            }

            HandleBoardEdges(newHeadPosition, boardWidth, boardHeight);
        }
        public void IncreaseSpeed(int multiplier, int durationInSeconds)
        {
            if (!isSpeedBoosted)
            {
                originalSpeed = Speed;
                Speed += multiplier;
                isSpeedBoosted = true;
                speedBoostEndTime = DateTime.Now.AddSeconds(durationInSeconds);
            }
        }
        public void ResetSpeed()
        {
            if (isSpeedBoosted && DateTime.Now >= speedBoostEndTime)
            {
                Speed = originalSpeed;
                isSpeedBoosted = false;
            }
        }
        public void UpdatePoints(int points, int lengthChange)
        {
            Points += points;
            pendingBodyParts += lengthChange;

            if (lengthChange < 0)
            {
                Shrink(-lengthChange);
            }
        }
        public void Shrink(int lengthToRemove)
        {
            for (int i = 0; i < lengthToRemove; i++)
            {
                if (bodyCoordinates.Count > 1)
                {
                    bodyCoordinates.RemoveAt(bodyCoordinates.Count - 1);
                }
            }
        }
        public List<Coordinate> GetBodyCoordinates() => new List<Coordinate>(bodyCoordinates);
        public Direction GetDirection() => currentDirection;
        public void SetDirection(Direction newDirection) => currentDirection = newDirection;
        public void CheckCollisionWith(Snake otherSnake)
        {
            if (otherSnake == this && pendingBodyParts > 0) return;

            var headCoordinate = bodyCoordinates[0]; // Get the head coordinate of this snake

            foreach (var coordinate in otherSnake.GetBodyCoordinates().Skip(1))
            {
                if (IsCollisionWithinRange(headCoordinate, coordinate, 5))
                {
                    gameEngine.RemoveSnake(this);
                    if (otherSnake != this)
                        otherSnake.UpdatePoints(5, 0);
                }
            }
        }

        #endregion

        #region Private methods

        private void HandleBoardEdges(Coordinate headPosition, int boardWidth, int boardHeight)
        {
            if (headPosition.X >= boardWidth || headPosition.X < 0 || headPosition.Y < 0 || headPosition.Y >= boardHeight)
                gameEngine.RemoveSnake(this);
        }
        private void InitializeBody(int length, Coordinate startPosition)
        {
            bodyCoordinates.Add(startPosition);

            for (int i = 1; i < length; i++)
            {
                int x = startPosition.X;
                int y = startPosition.Y + i * gameEngine.ObjectSize;
                bodyCoordinates.Add(new Coordinate(x, y));
            }
        }
        private Color GetColorById(int playerId)
        {
            return playerId switch
            {
                1 => Color.Green,
                2 => Color.Magenta,
                _ => Color.Black,
            };
        }
        private bool IsCollisionWithinRange(Coordinate coord1, Coordinate coord2, int range)
        {
            return Math.Abs(coord1.X - coord2.X) <= range && Math.Abs(coord1.Y - coord2.Y) <= range;
        }

        #endregion
    }
}