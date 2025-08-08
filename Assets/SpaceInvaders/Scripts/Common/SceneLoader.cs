using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for loading scenes in the game.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
