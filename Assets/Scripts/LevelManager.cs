using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject cheatManagerGO;
    public void ChangeLevel(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void cheatPlayer()
    {
        GameObject objectToFind = GameObject.Find("CheatManager");
        cheatManagerGO = objectToFind;
        cheatManagerGO.GetComponent<cheatScript>().cheat();
    }
}
