using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ_2018
{
    public class Game_Manager : MonoBehaviour
    {
        public GameObject pausePanel;
        public GameObject optionsPanel;

        public GameObject WinPanel;
        public GameObject LosePanel;

        private bool gamePaused = false;

        public static Game_Manager Instance;

        public Action OnWinLevel = delegate { };
        public Action OnLoseLevel = delegate {  };


        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            ScanForKeyStroke();
        }

        public void WinLevel()
        {
            WinPanel.SetActive(true);
            Debug.Log("Pause Menu up");
            OnWinLevel();
        }

        public void LoseLevel()
        {
            LosePanel.SetActive(true);
            OnLoseLevel();
        }

        public void PauseGame(GameObject pauseMenu)
        {
            pauseMenu.SetActive(true);
        }

        public void UnPauseGame(GameObject pauseMenu)
        {
            pauseMenu.SetActive(false);
        }

        public void EnterOptions()
        {
            optionsPanel.SetActive(true);
        }

        public void ExitOptions()
        {
            optionsPanel.SetActive(false);
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
            ResumeGameTime();
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


