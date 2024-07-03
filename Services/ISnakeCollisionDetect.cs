namespace Simply_Snake_Game.Services
{
    public interface ISnakeCollisionDetect
    {
        void CheckIfHitBounds(Snake snake);
        void CheckIfHitSelf(Snake snake);
    }
}