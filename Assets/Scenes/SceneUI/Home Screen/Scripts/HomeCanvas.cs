
using TMPro;
using UnityEngine;

public class HomeCanvas : MonoBehaviour
{

    public GameObject nickNameText;
    public GameObject scoreText;
    public GameObject coinText;

    void Start()
    {

    }

    void Update()
    {
        nickNameText.GetComponent<TextMeshProUGUI>().text = PlayerAccount.nickName;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score " + PlayerAccount.score;
        coinText.GetComponent<TextMeshProUGUI>().text = "Coin " + PlayerAccount.coin;

    }
}
