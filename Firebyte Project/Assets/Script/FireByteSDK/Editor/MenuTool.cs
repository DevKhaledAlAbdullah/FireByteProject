using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
public class MenuTool
{
    [MenuItem("Firebyte/Reset Data")]
    private static void RestData()
    {
        PlayerPrefs.DeleteAll();
    }
    [MenuItem("Firebyte/Core/Create/GameSettingSO")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<GameSettingManager>();
    }
    [MenuItem("Firebyte/Core/Create/LevelBuilderSO")]
    public static void CreateLevelBuilderAsset()
    {
        //ScriptableObjectUtility.CreateAsset<GameSettingManager>();
    }


}
