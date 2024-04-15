
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoreLevelUpCard : MonoBehaviour
{


    public GameObject levelText;
    public GameObject heathText;
    public GameObject speedText;
    public GameObject strengthText;
    public GameObject resistanceText;
    public GameObject priceText;
    public GameObject levelUpBtn;


    private void Start()
    {
        levelUpBtn.GetComponent<Button>().onClick.AddListener(LevelUpCharacter);
    }

    void Update()
    {
        levelText.GetComponent<TextMeshProUGUI>().text = "Level : " + (PlayerAccount.level + 1);
        heathText.GetComponent<TextMeshProUGUI>().text = "Health : " + (PlayerAccount.Health * 2);
        speedText.GetComponent<TextMeshProUGUI>().text = "Speed : " + (PlayerAccount.Speed + 0.1).ToString("F1");
        strengthText.GetComponent<TextMeshProUGUI>().text = "Strength : " + (PlayerAccount.Strength + 5);
        resistanceText.GetComponent<TextMeshProUGUI>().text = "Resistance : " + (PlayerAccount.DamageResistance + 0.05).ToString("F1");

        int levelUpCost = PlayerAccount.LevelUPPrice();
        priceText.GetComponent<Text>().text = levelUpCost.ToString();

        if (PlayerAccount.coin < levelUpCost)
        {
            levelUpBtn.GetComponent<Image>().color = Color.red;
        }


    }

    void LevelUpCharacter()
    {
        if (PlayerAccount.coin >= PlayerAccount.LevelUPPrice())
        {
            PlayerAccount.LevelUP();
        }

    }
}
