using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for life management of the player.
    /// </summary>
    public class PlayerLifeManager : LifeManager
    {
        protected override void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}

