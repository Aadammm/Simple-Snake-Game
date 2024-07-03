using Simply_Snake_Game.Enums;

namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public class ConsoleReader : IConsoleReader
    {
        public void GetDirection(ref Direction direction)
        {
            while (CheckIfKeyPress())
            {
                ConsoleKeyInfo pressKey = Console.ReadKey(true);
                if (pressKey.Key == ConsoleKey.RightArrow && direction != Direction.Left)
                    direction = Direction.Right;
                else if (pressKey.Key == ConsoleKey.LeftArrow && direction != Direction.Right)
                    direction = Direction.Left;
                else if (pressKey.Key == ConsoleKey.DownArrow && direction != Direction.Up)
                    direction = Direction.Down;
                else if (pressKey.Key == ConsoleKey.UpArrow && direction != Direction.Down)
                    direction = Direction.Up;
                else if (pressKey.KeyChar == 'q' || pressKey.KeyChar == 'Q')
                    direction = Direction.None;
            }
        }
        public bool CheckIfKeyPress() => Console.KeyAvailable;
        public char PressedKey() => Console.ReadKey().KeyChar;
    }
}
