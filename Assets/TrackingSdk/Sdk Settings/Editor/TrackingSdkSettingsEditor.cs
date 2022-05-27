using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TrackingSdkSettings))]
public class TrackingSdkSettingsEditor : UnityEditor.Editor
{
    private TrackingSdkSettings sdkSettings => target as TrackingSdkSettings;

    [MenuItem("Tracking Sdk/Create TrackingSdk GameObject", false, 200)]
    private static void InstantiateTrackingSdk()
    {
        if (FindObjectOfType(typeof(TrackingSdkManager)) == null)
        {
            GameObject go =
                PrefabUtility.InstantiatePrefab(
                    AssetDatabase.LoadAssetAtPath(ObjectLocater.WhereIs("TrackingSdk.prefab", "Prefab"),
                        typeof(GameObject))) as GameObject;
            go.name = "TrackingSdk";
            Selection.activeObject = go;
            Undo.RegisterCreatedObjectUndo(go, "Created Tracking Sdk Object");
        }
        else
        {
            Debug.LogWarning(
                "A Tracking Sdk object already exists in this scene ");
        }
    }


    [MenuItem("Tracking Sdk/Settings/Edit Settings")]
    private static void EditSettings()
    {
        Selection.activeObject = CreateTrackingSdkSettings();
    }


    private static TrackingSdkSettings CreateTrackingSdkSettings()
    {
        TrackingSdkSettings settings = TrackingSdkSettings.Load();
        if (settings == null)
        {
            settings = CreateInstance<TrackingSdkSettings>();

            var assetPath = "Assets/Resources/TrackingSdk/Settings.asset";
            Directory.CreateDirectory(Path.GetDirectoryName(assetPath));

            AssetDatabase.CreateAsset(settings, assetPath);
            settings = TrackingSdkSettings.Load();
        }

        return settings;
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);

#if UNITY_IOS || UNITY_ANDROID
        if (GUILayout.Button(Environment.NewLine + "Check and Sync Settings" + Environment.NewLine))
        {
            CheckAndSyncKeys(sdkSettings);
        }
#else
        EditorGUILayout.HelpBox("Invalid Platrform Convert to Ios/Android",MessageType.Error);
        Debug.LogError("Invalid Platrform Convert to Ios/Android");
#endif
    }


    private static void CheckAndSyncKeys(TrackingSdkSettings trackingSdkSettings)
    {
        Console.Clear();
        KeysManager.SetGAKeys(trackingSdkSettings);
        KeysManager.SetFBKeys(trackingSdkSettings);
    }
}