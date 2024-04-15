
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuySwordCard : MonoBehaviour
{

    public GameObject damageText;
    public GameObject speedText;
    public GameObject priceText;
    public GameObject buyBtn;


    private void Start()
    {
        gameObject.SetActive(false);
        buyBtn.GetComponent<Button>().onClick.AddListener(BuySelectedSword);
    }



    // Update is called once per frame
    void Update()
    {

        if (StoreCanvas.selectedStoreSwordSItem != null)
        {
            gameObject.SetActive(true);
            damageText.GetComponent<TextMeshProUGUI>().text = "Attack Damage : " + WeaponNames.AttackDamage(StoreCanvas.selectedStoreSwordSItem.swordName);
            speedText.GetComponent<TextMeshProUGUI>().text = "Attack Speed : " + WeaponNames.AttackSpeed(StoreCanvas.selectedStoreSwordSItem.swordName);
            priceText.GetComponent<TextMeshProUGUI>().text = "Price : " + WeaponNames.Price(StoreCanvas.selectedStoreSwordSItem.swordName);

            if (StoreCanvas.selectedStoreSwordSItem.isSold || PlayerAccount.coin < WeaponNames.Price(StoreCanvas.selectedStoreSwordSItem.swordName))
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
            gameObject.SetActive(false);

        }
    }


    void BuySelectedSword()
    {
        PlayerAccount.BuyWeapone(StoreCanvas.selectedStoreSwordSItem.swordName, WeaponNames.Price(StoreCanvas.selectedStoreSwordSItem.swordName));
        StoreCanvas.selectedStoreSwordSItem.isSold = true;
    }
}
