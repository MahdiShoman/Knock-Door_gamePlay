
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomDoorController : MonoBehaviour
{
    public GameObject txtToDisplay;
    public GameObject doorAnswerDisplay;
    public int currentAnswer;
    private Question question;
    private bool playerInZone;


    private void Start()
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
        question = GetComponentInParent<Question>();
    }

    private void OnTriggerEnter(Collider other)
    {
        txtToDisplay.SetActive(true);
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (
        doorAnswerDisplay.GetComponent<TextMeshPro>().text == "")
            doorAnswerDisplay.GetComponent<TextMeshPro>().text = question.answers[currentAnswer];
        if (playerInZone)
        {
            txtToDisplay.GetComponent<Text>().text = "Press 'E' to Open";
        }


        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            PlayerPrefs.SetInt("State", currentAnswer);
            SceneManager.LoadScene(MyScreen.MAZE1GAME);
        }
    }
}
