
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeathBar : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject heathTextGameObject;


    private Slider slider;
    private Player player;
    private TextMeshProUGUI heathText;



    void Start()
    {
        slider = GetComponent<Slider>();
        player = playerGameObject.GetComponent<Player>();
        heathText = heathTextGameObject.GetComponent<TextMeshProUGUI>();
        slider.maxValue = player.Health;
        slider.value = player.Health;
        heathText.text = player.Health.ToString();

    }

    void Update()
    {
        slider.value = player.Health;
        heathText.text = player.Health.ToString();
    }
}
