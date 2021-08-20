using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : ScriptableObject
{
    public static GameSettingManager instance;

    public void OnEnable()
    {
        instance = this;
    }

    public GameCore.GameSettingData gameSetting = new GameCore.GameSettingData();
    //public List<AlfucodeCore.VirtualItem> VI = new List<AlfucodeCore.VirtualItem>();
}
