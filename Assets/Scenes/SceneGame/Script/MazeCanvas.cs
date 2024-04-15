using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeCanvas : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject menuPanel;


    private bool winPanelShow = false;
    private bool losePanelShow = false;
    private bool menuPanelShow = false;


    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        menuPanel.SetActive(false);
    }
    private void Update()
    {

        DisplayPanal();
    }


    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuPanel.SetActive(false);
        menuPanelShow = false;
        Time.timeScale = 1;
        player.GetComponent<Player>().pause = false;
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        menuPanel.SetActive(true);
        menuPanelShow = true;
        player.GetComponent<Player>().pause = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MyScreen.HOMEUI);
    }


    private void DisplayPanal()
    {
        if (!winPanelShow && player != null && player.GetComponent<Player>().win)
        {
            Cursor.lockState = CursorLockMode.Confined;
            winPanel.SetActive(true);
            winPanelShow = true;
            PlayerAccount.coin += 100;
            PlayerAccount.score += 300;
        }
        else if (!losePanelShow && enemy != null && enemy.GetComponent<Enemy>().win)
        {
            Cursor.lockState = CursorLockMode.Confined;
            losePanel.SetActive(true);
            losePanelShow = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPanelShow)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }
}
