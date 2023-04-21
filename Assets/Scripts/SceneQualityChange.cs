using UnityEngine;

public class SceneQualityChange : MonoBehaviour
{
    public int level;
    void Start()
    {
        QualitySettings.SetQualityLevel(level);
    }
}