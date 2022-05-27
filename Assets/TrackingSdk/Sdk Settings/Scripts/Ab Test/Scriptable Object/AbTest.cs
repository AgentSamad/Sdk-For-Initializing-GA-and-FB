using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Resources/TrackingSdk/AbTestInfo", menuName = "Tracking Sdk/AbTesting")]
public class AbTest : ScriptableObject
{
    private const string Settings_Path = "TrackingSdk/AbTestInfo";

    public static AbTest Load() => Resources.Load<AbTest>(Settings_Path);

    public List<string> testVariants;
    private string currentVarient = null;


    public void UpdateCurrentVersion()
    {
        if (testVariants.Count != 0)
        {
            currentVarient = testVariants[Random.Range(0, testVariants.Count)];
            Debug.Log("Current Selection Updated " + currentVarient);
        }
    }

    public string GetCurrentVairent()
    {
        return currentVarient;
    }
}