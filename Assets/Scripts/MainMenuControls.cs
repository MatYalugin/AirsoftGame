using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControls : MonoBehaviour
{
    public GameObject controlsTip;

    // Update is called once per frame
    void Update()
    {
        controls();
    }
    public void controls()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            controlsTip.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controlsTip.SetActive(false);
        }
    }
}
