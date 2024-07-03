using Simply_Snake_Game;
using Simply_Snake_Game.ConsoleInteractor.Interface;
using Simply_Snake_Game.Services;

IConsoleUtility consoleUtility = new ConsoleUtility();
IConsoleReader consoleReader = new ConsoleReader();
IConsoleWriter consoleWriter = new ConsoleWriter();

Snake snake = new(consoleUtility);
Food food = new(snake, consoleUtility);
ISnakeCollisionDetect snakeCollisionDetect = new SnakeCollisionDetect(consoleUtility);

Game game = new(snake, food, snakeCollisionDetect, consoleUtility, consoleReader, consoleWriter);
try
{
    game.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}\n{game.Score} ");
}
Console.ReadKey();