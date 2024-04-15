using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        print("OnCollisionEnter");
        // This is for check if the collision make with Enemy Weapon tage
        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            print("PlayerWeapon");

        }

    }
}
