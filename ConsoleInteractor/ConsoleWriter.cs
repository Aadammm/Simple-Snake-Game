namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void PrintNewLine() => Console.WriteLine();
        public void PrintMessage(string message) => Console.WriteLine(message);
        public void PrintFood(Food food)
        {
            Console.CursorLeft = food.Position.Row;
            Console.CursorTop = food.Position.Column;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(food);
        }
        public void PrintSnakeOnPosition(Snake snake)
        {
            int snakeLength = snake.Positions.Count - 1;
            for (int i = snakeLength; i >= 0; --i)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.SetCursorPosition(snake.Positions[i].Row, snake.Positions[i].Column);
                Console.Write(snake.PartOfBody);
            }
        }
    }
}

