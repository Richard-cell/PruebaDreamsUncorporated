namespace SpaceInvaders
{
    public interface IPlayerLifeUIDrawer
    {
        void Configure(int lives);
        void DrawLives(int livesValue);
    }
}

