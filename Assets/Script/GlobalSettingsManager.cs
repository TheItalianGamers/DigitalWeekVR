using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[System.Serializable]
public static class GlobalSettings
{

    public static readonly string EasyMode = "Easy";
    public static readonly string HardMode = "Hard";

    public static string? LevelOfDifficulty = null;

}

public class GlobalSettingsManager : MonoBehaviour
{
    private GameObject XROrigin;
    private GameObject[] controlsGameObjects;
    public const string XR_ORIGIN_NAME = "XR Origin (XR Rig)";
    public const string HARD_MODE_TAG = "HardModeFeatures";

    void Awake()
    {
        XROrigin = GameObject.Find(XR_ORIGIN_NAME);
        controlsGameObjects = GameObject.FindGameObjectsWithTag(HARD_MODE_TAG);

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

        XROrigin.GetComponent<ActivateRayGrab>().enabled = false;
        XROrigin.GetComponent<ActivateMovementsTurnScript>().DisableMovementAction();
        XROrigin.GetComponent<ActivateMovementsTurnScript>().DisableTurnAction();
        
        // Disabling controllers and other:
        foreach (var obj in controlsGameObjects)
        {
            obj.SetActive(false);
        }

        Debug.Log("Easy Mode set!");
    }

    private void SetHardMode()
    {
        GlobalSettings.LevelOfDifficulty = GlobalSettings.HardMode;

        XROrigin.GetComponent<ActivateRayGrab>().enabled = true;
        XROrigin.GetComponent<ActivateMovementsTurnScript>().EnableMovementAction();
        XROrigin.GetComponent<ActivateMovementsTurnScript>().EnableTurnAction();

        // Enabling controllers and other:
        foreach (var obj in controlsGameObjects)
        {
            obj.SetActive(true);
        }

        Debug.Log("Hard Mode set!");
    }

}
