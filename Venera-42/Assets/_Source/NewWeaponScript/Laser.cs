using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public PlayerInventory inv;
    public Weapon1 weapon;
    public GameObject laser;
  

    void Start()
    {
        laser.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if (inv.currentWeapon != null)
        {
            if (inv.currentWeapon.scope)
            {
                laser.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                laser.GetComponent<Renderer>().enabled = false;
            }
        }
    }

}
