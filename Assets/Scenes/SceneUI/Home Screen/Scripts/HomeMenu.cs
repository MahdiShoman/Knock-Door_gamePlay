using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void PlayGameBtn()
    {
        SceneManager.LoadScene(MyScreen.MAZEUI);

    }
    public void CharacterBtn()
    {
        SceneManager.LoadScene(MyScreen.CHARACTERUI);

    }
    public void StoreBtn()
    {
        SceneManager.LoadScene(MyScreen.STOREUI);

    }
    public void QuitBtn()
    {
        Application.Quit();

    }
}
