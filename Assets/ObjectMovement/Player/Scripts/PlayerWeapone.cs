using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapone : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject currentWeapone;
    public Player player;
    void Start()
    {

        player = GetComponentInParent<Player>();
        currentWeapone = prefabs[0];

        /*for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i].name == player.Weapone)
            {
                currentWeapone = prefabs[i];
                break;
            }
        }*/

        currentWeapone = Instantiate(currentWeapone);
        currentWeapone.transform.SetParent(transform, false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.Weapone.Equals(currentWeapone.name))
        {
            DestroyImmediate(currentWeapone, true);
            for (int i = 0; i < prefabs.Length; i++)
            {
                if (prefabs[i].name == player.Weapone)
                {
                    currentWeapone = prefabs[i];
                    currentWeapone = Instantiate(currentWeapone);
                    currentWeapone.transform.SetParent(transform, false);
                    break;
                }
            }
        }
    }
}
