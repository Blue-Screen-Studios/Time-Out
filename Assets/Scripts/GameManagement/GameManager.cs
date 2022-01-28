using UnityEngine;
using UnityEngine.SceneManagement;
using SaveSystem;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject continueButton;

        void Start()
        {
            if (IO.ReadJSONSerialized() != null)
            {
                continueButton.SetActive(true);
            }

            AudioManager.instance.PlayMainMenuMusic();
        }

        public void NewGame()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(1);
        }

        public void Continue()
        {
            SaveData data = IO.ReadJSONSerialized();
        }

        public void QuitGame()
        {
            Application.Quit();

            Debug.Log("Game Quit");
        }
    }
}
