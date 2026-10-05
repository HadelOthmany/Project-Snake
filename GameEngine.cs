using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class GameEngine
    {

        #region Properties

        public int TotalPlayers { get; private set; }
        public int ActivePlayers { get; private set; }
        public int BoardHeight { get; private set; }
        public int BoardWidth { get; private set; }
        public int ObjectSize { get; private set; }
        public List<Snake> Snakes { get; private set; } = new List<Snake>();

        #endregion

        #region fields

        private int initialSnakeLength;
        private MainForm gameForm;
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer foodTimer = new System.Windows.Forms.Timer();
        private int moveCounter;
        private List<AbstractFood> foods = new List<AbstractFood>();

        #endregion

        #region Constructor

        public GameEngine()
        {
            gameForm = new MainForm(this);
            initialSnakeLength = 5;
        }

        #endregion

        #region public methods

        public void Run()
        {
            gameForm.KeyDown += OnKeyDown;
            gameForm.Paint += OnPaint;
            gameForm.Resize += OnResize;
            InitializeGameSettings();

            gameTimer.Tick += OnTimerTick;
            gameTimer.Interval = 1000 / 100; // Set to 100 fps

            foodTimer.Tick += OnFoodTimerTick;
            foodTimer.Interval = 2000; // Set to 3 seconds 

            Application.Run(gameForm);
        }
        public void RemoveFood(AbstractFood food) => foods.Remove(food);
        public void RemoveSnake(Snake snake)
        {
            Snakes.Remove(snake);
            ActivePlayers--;
        }

        #endregion

        #region private methods

        private void AddSnake(Snake snake) => Snakes.Add(snake);
        private void AddFood(AbstractFood food) => foods.Add(food);
        private void InitializeGameSettings()
        {
            BoardHeight = gameForm.Height - gameForm.Height / 8;
            BoardWidth = gameForm.Width - gameForm.Width / 20;
            ObjectSize = BoardWidth / 40;
        }
        private void OnResize(object sender, EventArgs e) => InitializeGameSettings();
        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var snake in new List<Snake>(Snakes))
                snake.Draw(e.Graphics);
            foreach (var food in new List<AbstractFood>(foods))
                food.Draw(e.Graphics);
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            gameForm.ScoreDisplay.Text = GetScoreText();
            gameForm.Refresh();
            CheckCollisions();
            UpdateMovement();

            if (Snakes.Count == 0) EndGame();
        }
        private void OnFoodTimerTick(object sender, EventArgs e) => AttemptToSpawnFood();
        public void StartGame(int numberOfPlayers)
        {
            gameTimer.Start();
            foodTimer.Start();
            ActivePlayers = TotalPlayers = numberOfPlayers;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Coordinate startCoordinate = new Coordinate(BoardWidth / 2 - (i * 4) * ObjectSize, BoardHeight / 2);
                AddSnake(new Snake(initialSnakeLength, startCoordinate, i + 1, this));
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            foreach (var snake in Snakes)
                MovementHandler.HandleMovement(e, snake);
        }
        private void CheckCollisions()
        {
            foreach (var food in new List<AbstractFood>(foods))
                foreach (var snake in new List<Snake>(Snakes))
                    if (food.Intersects(snake))
                        food.OnConsume(snake);

            foreach (var snake in new List<Snake>(Snakes))
                foreach (var otherSnake in new List<Snake>(Snakes))
                    snake.CheckCollisionWith(otherSnake);
        }
        private void UpdateMovement()
        {
            foreach (var snake in new List<Snake>(Snakes))
            {
                if (moveCounter < snake.Speed)
                {
                    snake.Move(BoardWidth, BoardHeight);
                    snake.ResetSpeed();
                }
            }

            moveCounter += 1;
            if (moveCounter == 10)
                moveCounter = 0;
        }
        private void AttemptToSpawnFood()
        {
            if (foods.Count >= ActivePlayers) return;

            Random rand = new Random();
            Coordinate foodCoordinate;
            List<Coordinate> snakeCoordinates = Snakes.SelectMany(snake => snake.GetBodyCoordinates()).ToList();

            do
            {
                foodCoordinate = new Coordinate(rand.Next(0, BoardWidth - ObjectSize), rand.Next(0, BoardHeight - ObjectSize));
            } while (snakeCoordinates.Contains(foodCoordinate));

            AddFood(FoodFactory.GenerateRandomFood(foodCoordinate.X, foodCoordinate.Y, this));
        }
        private void EndGame()
        {
            Snakes.Clear();
            foods.Clear();
            gameTimer.Stop();
            foodTimer.Stop();
            gameForm.RestartMenu();
        }
        private string GetScoreText()
        {
            string scoreText = Snakes.Aggregate("", (current, snake) => current + $"Player {snake.ID}: {snake.Points}\r\n");
            if (ActivePlayers == 1 && TotalPlayers > 1)
                scoreText += "WINNER!";
            return scoreText;
        }
        public void IncreaseSpeedOfRandomSnake(int multiplier, int durationInSeconds)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, Snakes.Count);
            Snakes[randomIndex].IncreaseSpeed(multiplier, durationInSeconds);
        }
        
        #endregion
    }
}