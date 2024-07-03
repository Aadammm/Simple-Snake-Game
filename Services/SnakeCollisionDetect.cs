using Simply_Snake_Game.ConsoleInteractor.Interface;

namespace Simply_Snake_Game.Services
{
    public class SnakeCollisionDetect(IConsoleUtility consoleUtility) : ISnakeCollisionDetect
    {
        readonly IConsoleUtility _consoleUtility = consoleUtility;
        public void CheckIfHitBounds(Snake snake)
        {
            int _borderWidth = _consoleUtility.BorderWidth;
            int _borderHeight = _consoleUtility.BorderHeight;
            int rowHeadPosition = snake.Positions[0].Row;
            int columnHeadPosition = snake.Positions[0].Column;

            if (rowHeadPosition < 0 || rowHeadPosition > _borderWidth - 2 ||
             columnHeadPosition < 0 || columnHeadPosition > _borderHeight - 1)
            {
                snake.CutHead();
                snake.Dies();
            }

        }
        public void CheckIfHitSelf(Snake snake)
        {
            Position position = snake.Positions.FirstOrDefault();
            if (snake.Positions.Count(x => x.Equals(position)) > 1)
            {
                snake.Dies();

            }

        }
    }
}
