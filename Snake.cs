using Simply_Snake_Game.ConsoleInteractor.Interface;
using Simply_Snake_Game.Enums;

namespace Simply_Snake_Game
{
    public class Snake
    {
        readonly IConsoleUtility _consoleUtility;
        public List<Position> Positions { get; private set; }
        public readonly string PartOfBody;
        public int Speed { get; set; }
        public bool Alive { get; protected set; }

        public Snake(IConsoleUtility consoleUtility)
        {
            _consoleUtility = consoleUtility;
            Alive = true;
            PartOfBody = "▓▓";
            Positions = [];
            CreateBodyWithPositions();
        }
        private void CreateBodyWithPositions()
        {
            int rowHeadPosition = _consoleUtility.BorderWidth / 2;
            int columnHeadPosition = _consoleUtility.BorderHeight / 2;
            Positions.AddRange(Enumerable.Range(0, 5)
                .Select(i => new Position(rowHeadPosition - 2 * i, columnHeadPosition)));
        }
        public Food? EatingFood(Food food, Difficulty difficulty)
        {
            if (!Positions.Contains(food.Position) && Alive)
            {
                Positions.RemoveAt(Positions.Count - 1);
            }
            else
            {
                food = null!;
                if (difficulty is Difficulty.Hard && Speed > 10)
                {
                    Speed -= 2;
                }
            }
            return food;
        }
        public void SnakeNextMove(Direction direction, Difficulty difficulty)
        {
            int rowHeadPosition = Positions[0].Row;
            int columnHeadPosition = Positions[0].Column;

            switch (direction)
            {
                case Direction.Right:
                    rowHeadPosition += 2;
                    break;
                case Direction.Left:
                    rowHeadPosition -= 2;
                    break;
                case Direction.Down:
                    columnHeadPosition += 1;
                    break;
                case Direction.Up:
                    columnHeadPosition -= 1;
                    break;
            }
            if (difficulty is Difficulty.Easy)
            {
                CrossTheBounds(ref rowHeadPosition, ref columnHeadPosition);
            }
            Positions.Insert(0, new Position(rowHeadPosition, columnHeadPosition));
        }
        private void CrossTheBounds(ref int rowHeadPosition, ref int columnHeadPosition)
        {
            int _borderWidth = _consoleUtility.BorderWidth;
            int _borderHeight = _consoleUtility.BorderHeight;

            if (rowHeadPosition > _borderWidth - 2)
                rowHeadPosition = 0;
            else if (rowHeadPosition < 0)
                rowHeadPosition = _borderWidth - 2;
            else if (columnHeadPosition > _borderHeight - 1)
                columnHeadPosition = 0;
            else if (columnHeadPosition < 0)
                columnHeadPosition = _borderHeight - 1;
        }
        public void CutHead()
        {
            Positions.RemoveAt(0);
        }
        public void Dies()
        {
            Alive = false;
        }
    }
}