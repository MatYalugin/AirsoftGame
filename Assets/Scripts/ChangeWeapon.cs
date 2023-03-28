using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject activeWeapon;
    public GameObject knife;
    public GameObject grenade;
    public GameObject pistol;
    public GameObject rifle;
    //kit1
    public GameObject pistolKit1;
    public GameObject rifleKit1;
    //kit2
    public GameObject pistolKit2;
    public GameObject rifleKit2;
    //kit3
    public GameObject pistolKit3;
    public GameObject rifleKit3;

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && knife != null)
        {
            if(activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = knife;
            activeWeapon.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && pistol != null)
        {
            if (activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = pistol;
            activeWeapon.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && rifle != null)
        {
            if (activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = rifle;
            activeWeapon.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && grenade != null)
        {
            if (activeWeapon != null)
            {
                activeWeapon.SetActive(false);
            }
            activeWeapon = grenade;
            activeWeapon.SetActive(true);
        }
    }
    public void changeWeaponsToFirstKit()
    {
        pistol = pistolKit1;
        rifle = rifleKit1;
        activeWeapon = rifleKit1;
    }
    public void changeWeaponsToSecondKit()
    {
        pistol = pistolKit2;
        rifle = rifleKit2;
        activeWeapon = rifleKit2;
    }
    public void changeWeaponsToThirdKit()
    {
        pistol = pistolKit3;
        rifle = rifleKit3;
        activeWeapon = rifleKit3;
    }
}
