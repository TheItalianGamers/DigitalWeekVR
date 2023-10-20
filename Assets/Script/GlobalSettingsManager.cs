using UnityEngine;

[System.Serializable]
public static class GlobalSettings
{

    public static readonly string EasyMode = "Easy";
    public static readonly string HardMode = "Hard";

    public static string? LevelOfDifficulty = null;

}

public class GlobalSettingsManager : MonoBehaviour
{
    void Awake()
    {
        if (GlobalSettings.LevelOfDifficulty == null)
        {
            SetEasyMode();
        }
    }

    public void SetDifficultyMode(string newMode)
    {

        if (newMode == GlobalSettings.EasyMode)
            SetEasyMode();
        else if (newMode == GlobalSettings.HardMode)
            SetHardMode();

    }

    private void SetEasyMode()
    {
        GlobalSettings.LevelOfDifficulty = GlobalSettings.EasyMode;

        Debug.Log("Easy Mode set!");
    }

    private void SetHardMode()
    {
        GlobalSettings.LevelOfDifficulty = GlobalSettings.HardMode;

        Debug.Log("Hard Mode set!");
    }

}
