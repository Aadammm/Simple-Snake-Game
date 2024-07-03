using Simply_Snake_Game.ConsoleInteractor.Interface;

namespace Simply_Snake_Game
{
    public class Food
    {
        readonly IConsoleUtility _utility;
        public Position Position { get; set; }
        public const string FoodForSnake = "██";
        private readonly Random random;

        public Food(Snake snake, IConsoleUtility utility)
        {
            _utility = utility;
            random = new Random();
            CreateNewFoodInAvailablePosition(snake.Positions);
        }
        private void CreateNewFoodInAvailablePosition(List<Position> snakeBodyPosition)
        {
            int RowPosition;
            int ColumnPosition;
            do
            {
                RowPosition = random.Next(0, _utility.BorderWidth);
                RowPosition = RowPosition % 2 == 0 ? RowPosition : RowPosition - 1;

                ColumnPosition = random.Next(0, _utility.BorderHeight - 1);
                Position = new Position(RowPosition, ColumnPosition);
            } while (snakeBodyPosition.Contains(Position));

        }
        public override string? ToString() => FoodForSnake;
    }
}
