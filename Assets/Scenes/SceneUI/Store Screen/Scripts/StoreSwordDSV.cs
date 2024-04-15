
using System.Collections.Generic;
using UnityEngine;

public class StoreSwordDSV : MonoBehaviour
{
    public Transform scrollViewContent;
    public GameObject swordPrefab;
    public List<Sprite> swords;

    private void Start()
    {
        foreach (var sword in swords)
        {
            GameObject gameObject = Instantiate(swordPrefab, scrollViewContent);
            StoreSwordSItem tmpItem = gameObject.GetComponent<StoreSwordSItem>();
            tmpItem.ChangeImage(sword);
            tmpItem.name = sword.name;
            tmpItem.swordName = sword.name;
            bool isSold = false;
            foreach (var item in PlayerAccount.Weapones)
            {
                if (item.Equals(sword.name))
                {
                    isSold = true;
                    break;
                }
            }
            tmpItem.isSold = isSold;
        }
    }




}
