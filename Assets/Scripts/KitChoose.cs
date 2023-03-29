using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChoose : MonoBehaviour
{
    public GameObject activeWeaponKit1;
    public GameObject activeWeaponKit2;
    public GameObject activeWeaponKit3;
    public MonoBehaviour weaponGrenade;
    public Animator playerAnimator;
    public GameObject chooseKitMenu;
    public GameObject playerGO;
    public GameObject playerCameraGO;
    public GameObject playButton;
    public bool isCursorOnGO;
    public GameObject cursorOnGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void kitChooseFirst()
    {
        activeWeaponKit1.SetActive(true);
        activeWeaponKit2.SetActive(false);
        activeWeaponKit3.SetActive(false);
        playerGO.GetComponent<ChangeWeapon>().changeWeaponsToFirstKit();
        playerAnimator.Play("ActiveWeapon_weaponOff");
        playButton.SetActive(true);
    }
    public void kitChooseSecond()
    {
        activeWeaponKit3.SetActive(false);
        activeWeaponKit2.SetActive(true);
        activeWeaponKit1.SetActive(false);
        playerGO.GetComponent<ChangeWeapon>().changeWeaponsToSecondKit();
        playerAnimator.Play("ActiveWeapon_weaponOff");
        playButton.SetActive(true);
    }
    public void kitChooseThird()
    {
        activeWeaponKit3.SetActive(true);
        activeWeaponKit2.SetActive(false);
        activeWeaponKit1.SetActive(false);
        playerGO.GetComponent<ChangeWeapon>().changeWeaponsToThirdKit();
        playerAnimator.Play("ActiveWeapon_weaponOff");
        playButton.SetActive(true);
    }
    public void endChoosing()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        chooseKitMenu.SetActive(false);
        playerAnimator.Play("ActiveWeapon_weaponOff");
        playerCameraGO.GetComponent<FirstPersonLook>().lookOn();
        weaponGrenade.GetComponent<GrenadeThrow>().enabled = true;
        if (isCursorOnGO == true)
        {
            Destroy(cursorOnGO);
        }
    }
}
