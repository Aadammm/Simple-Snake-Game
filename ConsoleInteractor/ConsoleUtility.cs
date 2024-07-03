namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public class ConsoleUtility : IConsoleUtility
    {
        public int BorderHeight => Console.WindowHeight;
        public int BorderWidth => Console.WindowWidth;
        public void CleanConsole() => Console.Clear();
        public void CollorReset() => Console.ResetColor();
        public void SetCollor(ConsoleColor color) => Console.ForegroundColor = color;
        public void SetCursorPosition(int row, int column) => Console.SetCursorPosition(row, column);
        public void SetCursorVisible(bool showCursor) => Console.CursorVisible = showCursor;
    }
}