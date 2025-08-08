namespace SpaceInvaders
{
    public interface IPlayerSpawner
    {
        public PlayerData PlayerSpawned { get; set; }
        void SpawnPlayer(PlayerData playerToSpawn);
        void ResetPosition();
        void Reset();
    }
}

