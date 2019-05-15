using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Weapon currentWeapon;

   

    // Update is called once per frame
    void Update()
    {
        // If there is a current weapon and can attack
        if (currentWeapon && currentWeapon.canAttack)
        {
            // if the fire button is pressed
            if (Input.GetButton("Fire1"))
            {
                // Attack
                currentWeapon.Attack();
            }
        }
    }
}
