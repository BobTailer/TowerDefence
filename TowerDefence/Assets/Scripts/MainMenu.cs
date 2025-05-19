using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TowerDefence
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button continueButton;

        private void Start()
        {
            continueButton.interactable = FileHandler.HaveFile(MapComlition.fileName);
        }

        public void NewGame()
        {
            FileHandler.Reset(MapComlition.fileName);
            SceneManager.LoadScene(1);
        }

        public void Continue()
        {
            SceneManager.LoadScene(1);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
