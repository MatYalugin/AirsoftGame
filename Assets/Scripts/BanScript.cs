using UnityEngine;
using System;

public class BanScript : MonoBehaviour
{
    public void Ban()
    {
        // Вычисляем время окончания бана
        DateTime endTime = DateTime.Now.AddMinutes(1);

        // Сохраняем время окончания бана в PlayerPrefs
        PlayerPrefs.SetString("banEndTime", endTime.ToString());

        // Запрещаем игроку входить в игру
        Application.Quit();
    }

    private void Start()
    {
        // Получаем время окончания бана из PlayerPrefs
        string banEndTimeString = PlayerPrefs.GetString("banEndTime", "");
        if (!string.IsNullOrEmpty(banEndTimeString))
        {
            DateTime banEndTime = DateTime.Parse(banEndTimeString);

            // Если время окончания бана еще не наступило, закрываем игру
            if (DateTime.Now < banEndTime)
            {
                Application.Quit();
            }
            else
            {
                // Если время окончания бана наступило, удаляем его из PlayerPrefs
                PlayerPrefs.DeleteKey("banEndTime");
            }
        }
    }
}
