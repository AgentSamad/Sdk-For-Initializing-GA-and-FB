using UnityEditor;

public class ObjectLocater
{
    public static string WhereIs(string _file, string _type)
    {
        string[] guids = AssetDatabase.FindAssets("t:" + _type);
        foreach (string g in guids)
        {
            string p = AssetDatabase.GUIDToAssetPath(g);
            if (p.EndsWith(_file))
            {
                return p;
            }
        }

        return "";
    }
}