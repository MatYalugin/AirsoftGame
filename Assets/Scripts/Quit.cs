using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Exit();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
