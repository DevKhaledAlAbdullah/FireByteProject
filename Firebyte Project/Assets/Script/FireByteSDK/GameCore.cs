using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameCore
{

    /// <summary>
    /// game setting class containe information game.
    /// </summary>
    [Serializable]
    public class GameSettingData
    {
        public float speedPlayer;
        public float speedMovementRightLeft;
        public float speedShootRate;
        public float speedEnemy;
    }

    /// <summary>
    /// for read scriptable object in run time.
    /// </summary>
    [Serializable]
    public class FireByteSettingManagerRun
    {
        public GameCore.GameSettingData gameSetting = new GameCore.GameSettingData();
    }

    /// <summary>
    /// read scriptable object in intialize the game.
    /// </summary>
    /// <returns></returns>
    public FireByteSettingManagerRun ReadManagerSetting()
    {
        GameSettingManager gameSettingData = new GameSettingManager();
        gameSettingData = Resources.Load("GameSettingManager") as GameSettingManager;

        FireByteSettingManagerRun settings = new FireByteSettingManagerRun();
        settings.gameSetting = gameSettingData.gameSetting;
        return settings;
    }
}
