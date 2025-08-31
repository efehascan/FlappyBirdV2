using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Scripts.UI.MainMenu
{
    public class MainMenuButtonManager : MonoBehaviour
    {

        
        public void OpenCostumeMenu()
        {
            Debug.Log("Opening costume menu");
        }
        
        public void PlayButton()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGameButton()
        {
            Application.Quit();
        }
        
    }
}