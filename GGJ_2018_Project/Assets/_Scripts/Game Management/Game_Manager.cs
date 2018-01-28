using UnityEngine;
using UnityEngine.SceneManagement;



namespace GGJ_2018_AP
{
    public class Game_Manager : MonoBehaviour
    {
        public GameObject pausePanel;
        private bool gamePaused = false;
        private void Update()
        {
            ScanForKeyStroke();
        }

        public void YouWin(GameObject WinPanel)
        {
            WinPanel.SetActive(true);
            Debug.Log("Pause Menu up");
        }

        public void YouLose(GameObject defeatMenu)
        {
            defeatMenu.SetActive(true);

        }

        public void PauseGame(GameObject pauseMenu)
        {
            pauseMenu.SetActive(true);
        }

        public void UnPauseGame(GameObject pauseMenu)
        {
            pauseMenu.SetActive(false);
        }

        public void StopGameTime()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGameTime()
        {
            Time.timeScale = 1.0f;
        }

        public void LoadNextScene(int nextSceneLevel)
        {
            SceneManager.LoadScene(nextSceneLevel, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        private void ScanForKeyStroke()
        {
            if (Input.GetKeyDown("escape") && gamePaused == false)
            {
                PauseGame(pausePanel);
                StopGameTime();
                gamePaused = true;
            }
            else if(Input.GetKeyDown("escape") && gamePaused == true)
            {
                UnPauseGame(pausePanel);
                ResumeGameTime();
                gamePaused = false;
            }
        }
    }
}


