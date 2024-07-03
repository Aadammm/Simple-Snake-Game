using Simply_Snake_Game.ConsoleInteractor.Interface;
using Simply_Snake_Game.Enums;
using Simply_Snake_Game.Services;

namespace Simply_Snake_Game
{
    public class Game(Snake snake, Food food, ISnakeCollisionDetect collisionDetect,
        IConsoleUtility consoleUtility, IConsoleReader consoleReader, IConsoleWriter consoleWriter)
    {
        readonly IConsoleUtility _consoleUtility = consoleUtility;
        readonly IConsoleReader _consoleReader = consoleReader;
        readonly IConsoleWriter _consoleWriter = consoleWriter;
        readonly ISnakeCollisionDetect collisionDetect = collisionDetect;
        Direction _direction = Direction.Right;
        Difficulty _difficulty;

        readonly Snake _snake = snake;
        private Food _food = food;
        public int Score { get; private set; }
        private bool GameOver = false;

        public void Run()
        {
            Introduction();

            while (!GameOver)
            {
                _consoleUtility.CleanConsole();
                _consoleWriter.PrintSnakeOnPosition(_snake);
                _consoleWriter.PrintFood(_food);

                _consoleReader.GetDirection(ref _direction);
                _snake.SnakeNextMove(_direction, _difficulty);

                _food = _snake.EatingFood(_food, _difficulty)!;
                IfFoodISNullCreateNew();

                SnakeCollisionCheck();

                GameStatusCheck();

                Thread.Sleep(_snake.Speed);
            }

            Score = _snake.Positions.Count - 4;
            LastLookAtSnake();
            EndMessage();
        }
        private void IfFoodISNullCreateNew()
        {
            _food ??= new Food(_snake, _consoleUtility);
        }
        private void SnakeCollisionCheck()
        {
          collisionDetect.CheckIfHitBounds(_snake);
            if (_difficulty is not Difficulty.Easy)
            {
                 collisionDetect.CheckIfHitSelf(_snake);
            }
        }
        private void GameStatusCheck()
        {
            GameOver = !_snake.Alive || _direction is Direction.None;
        }
        private void LastLookAtSnake()
        {
            for (int i = 0; i < 5; i++)
            {
                _consoleUtility.CleanConsole();
                Thread.Sleep(100);
                _consoleWriter.PrintSnakeOnPosition(_snake);
                Thread.Sleep(300);
            }
        }
        private void Introduction()
        {
            var choice = (char)default;
            var index = 0;
            _consoleUtility.SetCursorVisible(false);
            while (IsValidChoice(choice))
            {
                index = ColorsCycle(index);
                ShowIntroductionMessages();

                Thread.Sleep(100);
                if (_consoleReader.CheckIfKeyPress())
                {
                    choice = _consoleReader.PressedKey();
                    switch (choice)
                    {
                        case '1':
                            _difficulty = Difficulty.Easy;
                            break;
                        case '2':
                            _difficulty = Difficulty.Medium;
                            break;
                        case '3':
                            _difficulty = Difficulty.Hard;
                            break;
                        default:
                            _consoleWriter.PrintNewLine();
                            _consoleUtility.SetCursorPosition(Console.WindowWidth / 2 - 19, 20);
                            _consoleWriter.PrintMessage("Stlač prosím klávesu v rámci voľby");
                            break;
                    }
                    _snake.Speed = (int)_difficulty;
                }
            }
        }

        private void ShowIntroductionMessages()
        {
            int midPosition = _consoleUtility.BorderWidth / 2;
            var intro = "Lucifer je hladný...";
            _consoleUtility.SetCursorPosition(midPosition - intro.Length / 2, 5);
            _consoleWriter.PrintMessage(intro);
            _consoleUtility.SetCollor(ConsoleColor.White);

            var text2 = "Ak ho chceš nakŕmiť easy stlač 1";
            _consoleUtility.SetCursorPosition(midPosition - text2.Length / 2, 8);
            _consoleWriter.PrintMessage(text2);

            var text3 = "Ak normálne stlač 2";
            _consoleUtility.SetCursorPosition(midPosition - text3.Length / 2, 9);
            _consoleWriter.PrintMessage(text3);

            var text4 = "A ak mu chceš dať rádioaktívnu potravu stlač 3";
            _consoleUtility.SetCursorPosition(midPosition - text4.Length / 2, 10);
            _consoleWriter.PrintMessage(text4);
        }

        private int ColorsCycle(int index)
        {
            ConsoleColor[] collors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.White];
            _consoleUtility.SetCollor(collors[index]);
            index++;
            if (index > 2)
                index = 0;
            return index;
        }
        private bool IsValidChoice(char choose) => choose != '1' && choose != '2' && choose != '3';
        private void EndMessage()
        {
            _consoleUtility.CollorReset();
            _consoleUtility.CleanConsole();

            _consoleUtility.SetCollor(ConsoleColor.Red);
            Console.WriteLine(@"
______  __ __    ___        ___  ____   ___   
|      ||  |  |  /  _]      /  _]|    \ |   \  
|      ||  |  | /  [_      /  [_ |  _  ||    \ 
|_|  |_||  _  ||    _]    |    _]|  |  ||  D  |
  |  |  |  |  ||   [_     |   [_ |  |  ||     |
  |  |  |  |  ||     |    |     ||  |  ||     |
  |__|  |__|__||_____|    |_____||__|__||_____|");
            _consoleUtility.SetCollor(ConsoleColor.Yellow);
            switch (Score)
            {
                case < 5:
                    _consoleUtility.SetCursorPosition(27, 15);
                    _consoleWriter.PrintMessage($"Tvoje skóre je : {Score} nb");
                    _consoleUtility.SetCursorPosition(0, 29);
                    _consoleWriter.PrintMessage("Lucifer ťa zožral !!");
                    break;
                case >= 5 and <= 15:
                    _consoleUtility.SetCursorPosition(26, 15);
                    _consoleWriter.PrintMessage("Tvoje skóre je: " + Score + " GB");
                    break;
                case > 15:
                    _consoleUtility.SetCursorPosition(23, 15);
                    _consoleWriter.PrintMessage("Excelentne ! Lucifer je spokojný a môžeš ho pohladkať");
                    _consoleUtility.SetCursorPosition(40, 16);
                    _consoleWriter.PrintMessage("SCORE: " + Score);
                    break;

            }

        }


    }
}