using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// scriptable object class 
/// </summary>
public class GameSettingManager : ScriptableObject
{
    public static GameSettingManager instance;

    public void OnEnable()
    {
        instance = this;
    }

    public GameCore.GameSettingData gameSetting = new GameCore.GameSettingData();
}
