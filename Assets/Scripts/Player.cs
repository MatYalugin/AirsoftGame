using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public float Health = 1;
    public float MaxHealth = 1;
    public GameObject DeathMenu;
    public GameObject cheatMenu;
    public GameObject controlsTip;
    public GameObject cursor;
    public Camera playerCamera;
    // Update is called once per frame
    void Update()
    {
        controls();
        goToMain();
        weaponAiming();
        if(cheatMenu.activeSelf == true)
        {
            DeathMenu.SetActive(false);
        }
    }
    public void goToMain()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Y))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Hurt(float damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            if (Random.value < 0.05f)
            {
                cheatMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                playerCamera.GetComponent<FirstPersonLook>().sensitivity = 0f;
            }
            else
            {
                DeathMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                playerCamera.GetComponent<FirstPersonLook>().sensitivity = 0f;
            }
        }
    }
    public void cheat()
    {
        Health = 1;
        cheatMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        playerCamera.GetComponent<FirstPersonLook>().sensitivity = 0.5f;
    }
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void controls()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            controlsTip.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controlsTip.SetActive(false);
        }
    }
    public void weaponAiming()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            cursor.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            cursor.SetActive(false);
        }
    }
}
