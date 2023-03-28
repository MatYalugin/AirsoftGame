using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOn : MonoBehaviour
{
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.Play("ActiveWeapon_weaponOff");
        Cursor.lockState = CursorLockMode.None;
    }
}
