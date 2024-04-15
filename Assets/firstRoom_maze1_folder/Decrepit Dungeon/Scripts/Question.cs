using System.Collections;

using TMPro;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string question;
    public string[] answers;
    public int[] corrects;
    public GameObject doorQuestionDisplay;

    private void Start()
    {
        question = "In the context of climate change, is it accurate to say that human activities, such as the burning of fossil fuels, significantly contribute to the increase in greenhouse gas emissions?";
        answers = new string[3];
        corrects = new int[3];
        answers[0] = "True";
        answers[1] = "Almost True";
        answers[2] = "False";
        doorQuestionDisplay.GetComponent<TextMeshPro>().text = question;
    }
}
