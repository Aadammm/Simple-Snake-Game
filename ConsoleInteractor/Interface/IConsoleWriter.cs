namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public interface IConsoleWriter
    {
        void PrintFood(Food food);
        void PrintNewLine();
        void PrintMessage(string message);
        void PrintSnakeOnPosition(Snake snake);
    }
}