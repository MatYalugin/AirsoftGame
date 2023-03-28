using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private float health = 10;
    private GameObject cheatManagerGO;

    public void Hurt(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            cheatManagerGO.GetComponent<cheatScript>().shootingBanMassage();
            cheatManagerGO.GetComponent<cheatScript>().CloseApplication();
        }
    }
    public void Start()
    {
        GameObject objectToFind = GameObject.Find("CheatManager");
        cheatManagerGO = objectToFind;
    }
}
