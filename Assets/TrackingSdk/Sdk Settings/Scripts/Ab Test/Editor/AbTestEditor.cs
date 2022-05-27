using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbTest))]
public class AbTestEditor : UnityEditor.Editor
{
    [MenuItem("Tracking Sdk/Set Tests")]
    private static void SetTests()
    {
        Selection.activeObject = AbTestingSettings();
    }


    private static AbTest AbTestingSettings()
    {
        AbTest settings = AbTest.Load();
        if (settings == null)
        {
            settings = CreateInstance<AbTest>();

            var assetPath = "Assets/Resources/TrackingSdk/AbTestInfo.asset";
            Directory.CreateDirectory(Path.GetDirectoryName(assetPath));

            AssetDatabase.CreateAsset(settings, assetPath);
            settings = AbTest.Load();
        }

        return settings;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);
        if (GUILayout.Button(Environment.NewLine + "Check And Start Testing" + Environment.NewLine))
        {
            InitializeTAbTestGameObject();
        }
    }


    private void InitializeTAbTestGameObject()
    {
        if (FindObjectOfType(typeof(InitializeABTest)) == null)
        {
            GameObject go =
                PrefabUtility.InstantiatePrefab(
                    AssetDatabase.LoadAssetAtPath(ObjectLocater.WhereIs("AbTest.prefab", "Prefab"),
                        typeof(GameObject))) as GameObject;
            go.name = "AbTest";
            Selection.activeObject = go;
            Undo.RegisterCreatedObjectUndo(go, "Ab Test Object Created");
        }
        else
        {
            Debug.LogWarning(
                "Ab Test GameObject Already Exist");
        }
    }
}