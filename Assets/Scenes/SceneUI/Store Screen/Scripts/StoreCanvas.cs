
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreCanvas : MonoBehaviour
{
    public static StoreSwordSItem selectedStoreSwordSItem;
    public GameObject coinText;


    public GameObject buyCard;
    public GameObject damageText;
    public GameObject speedText;
    public GameObject priceText;
    public GameObject buyBtn;


    private void Start()
    {
        buyCard.SetActive(false);
        buyBtn.GetComponent<Button>().onClick.AddListener(BuySelectedSword);
    }



    // Update is called once per frame
    void Update()
    {
        coinText.GetComponent<TextMeshProUGUI>().text = "Coin : " + PlayerAccount.coin;
        if (selectedStoreSwordSItem != null)
        {
            buyCard.SetActive(true);

            damageText.GetComponent<TextMeshProUGUI>().text = "Attack Damage : " + WeaponNames.AttackDamage(selectedStoreSwordSItem.swordName);
            speedText.GetComponent<TextMeshProUGUI>().text = "Attack Speed : " + WeaponNames.AttackSpeed(selectedStoreSwordSItem.swordName);
            priceText.GetComponent<TextMeshProUGUI>().text = "Price : " + WeaponNames.Price(selectedStoreSwordSItem.swordName);

            if (selectedStoreSwordSItem.isSold || PlayerAccount.coin < WeaponNames.Price(selectedStoreSwordSItem.swordName))
            {
                buyBtn.SetActive(false);
            }
            else
            {
                buyBtn.SetActive(true);
            }
        }
        else
        {
            buyCard.SetActive(false);

        }
    }


    void BuySelectedSword()
    {
        PlayerAccount.BuyWeapone(selectedStoreSwordSItem.swordName, WeaponNames.Price(selectedStoreSwordSItem.swordName));
        selectedStoreSwordSItem.isSold = true;
    }
}
