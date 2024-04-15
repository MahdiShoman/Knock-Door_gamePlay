using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwordDSV : MonoBehaviour
{
    public Transform scrollViewContent;
    public GameObject swordPrefab;
    public List<Sprite> swords;

    private void Start()
    {
        foreach (var sword in swords)
        {
            bool exist = false;
            foreach (var tmpSword in PlayerAccount.Weapones)
            {
                if (tmpSword == sword.name)
                {
                    exist = true;
                    break;
                }
            }
            if (exist)
            {
                GameObject gameObject = Instantiate(swordPrefab, scrollViewContent);
                CharacterSwordSItem tmpItem = gameObject.GetComponent<CharacterSwordSItem>();
                tmpItem.ChangeImage(sword);
                tmpItem.name = sword.name;
                tmpItem.swordName = sword.name;
            }

        }
    }




}
