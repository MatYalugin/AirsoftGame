using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

public class cheatScript : MonoBehaviour
{
    public GameObject player;
    public GameObject cheatMenu;
    public Camera playerCamera;

    public string messageOnDesktop = "You were found in cheating!";

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(System.IntPtr hWnd);
    public void cheat()
    {
        player.gameObject.GetComponent<Player>().Health = 1f;
        cheatMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        playerCamera.GetComponent<FirstPersonLook>().sensitivity = 0.5f;
        if (Random.value < 0.4f)
        {
            CloseApplication();
        }
    }
    public void CloseApplication()
    {
        // Показываем окно
        ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 9);
        SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);

        // Сохраняем файл на рабочем столе
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "message.txt");
        System.IO.File.WriteAllText(filePath, messageOnDesktop);

        // Дожидаемся завершения записи в файл
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
        while (fileInfo.Exists && fileInfo.Length == 0)
        {
            fileInfo.Refresh();
        }

        // баним игрока
        gameObject.GetComponent<BanScript>().Ban();
    }
    public void shootingBanMassage()
    {
        messageOnDesktop = "Do not shoot death enemies! You were banned for 1 minute";
    }
}
