using UnityEngine;
using UnityEngine.SceneManagement;

public class BackHomeBtn : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(MyScreen.HOMEUI);
    }

}
