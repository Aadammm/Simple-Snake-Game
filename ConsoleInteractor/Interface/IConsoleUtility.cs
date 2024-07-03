namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public interface IConsoleUtility
    {
        int BorderHeight { get; }
        int BorderWidth { get; }
        void CollorReset();
        void CleanConsole();
        void SetCollor(ConsoleColor color);
        void SetCursorPosition(int row, int column);
        void SetCursorVisible(bool showCursor);
    }
}