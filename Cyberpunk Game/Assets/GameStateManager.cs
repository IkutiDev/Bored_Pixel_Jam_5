using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public void WinGame()
    {
        FindObjectOfType<SceneManager>().NextScene();
    }

    public void LooseGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        FindObjectOfType<SceneManager>().SpecificScene("Level 1");
    }
}
