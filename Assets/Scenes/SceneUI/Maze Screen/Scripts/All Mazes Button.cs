using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMazesButton : MonoBehaviour
{


    public void OnM1Click()
    {
        SceneManager.LoadScene(MyScreen.MAZE1ROOM);
    }

}
