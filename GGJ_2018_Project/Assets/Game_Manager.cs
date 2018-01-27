using UnityEngine;
using UnityEngine.SceneManagement;



namespace GGJ_2018_AP
{
    public class Game_Manager : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject defeatMenu;
        public GameObject victoryMenu;
        public int nextSceneLevel;

        public void YouWin()
        {
            victoryMenu.SetActive(true);
        }

        public void YouLose()
        {
            defeatMenu.SetActive(true);

        }

        public void PausedGame()
        {
            pauseMenu.SetActive(true);
        }

        public void StopGameTime()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGameTime()
        {
            Time.timeScale = 1.0f;
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(nextSceneLevel, LoadSceneMode.Single);
        }
    }
}


