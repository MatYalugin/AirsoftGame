using UnityEngine;

public class SceneQualityChange : MonoBehaviour
{
    void Start()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel());
    }
}