
using TMPro;
using UnityEngine;

public class CharacterCanvas : MonoBehaviour
{
    public GameObject heathText;
    public GameObject speedText;
    public GameObject strengthText;
    public GameObject resistanceText;
    public GameObject damageText;
    public GameObject steedText;


    // Update is called once per frame
    void Update()
    {
        heathText.GetComponent<TextMeshProUGUI>().text = "Health : " + PlayerAccount.Health;
        speedText.GetComponent<TextMeshProUGUI>().text = "Speed : " + PlayerAccount.Speed;
        strengthText.GetComponent<TextMeshProUGUI>().text = "Strength : " + PlayerAccount.Strength;
        resistanceText.GetComponent<TextMeshProUGUI>().text = "Resistance : " + PlayerAccount.DamageResistance;

        damageText.GetComponent<TextMeshProUGUI>().text = "Attack Damage : " + WeaponNames.AttackDamage(PlayerAccount.SelectedWeapone);
        steedText.GetComponent<TextMeshProUGUI>().text = "Attack Speed : " + WeaponNames.AttackSpeed(PlayerAccount.SelectedWeapone);
    }
}
