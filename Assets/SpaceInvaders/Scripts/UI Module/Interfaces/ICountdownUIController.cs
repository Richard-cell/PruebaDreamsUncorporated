using System;

namespace SpaceInvaders
{
    public interface ICountdownUIController
    {
        event Action OnCountdownFinished;
        void StartCountdown();
        void ResetCountdown();
    }
}
