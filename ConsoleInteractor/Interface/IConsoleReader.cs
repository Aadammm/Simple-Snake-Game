using Simply_Snake_Game.Enums;

namespace Simply_Snake_Game.ConsoleInteractor.Interface
{
    public interface IConsoleReader
    {
        bool CheckIfKeyPress();
        char PressedKey();
        void GetDirection(ref Direction direction);
    }
}