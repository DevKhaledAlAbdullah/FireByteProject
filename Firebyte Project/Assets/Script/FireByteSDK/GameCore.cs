using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameCore
{
    [Serializable]
    public class GameSettingData
    {
        public float speedPlayer;
        public float speedMovementRightLeft;
        public float speedShootRate;
        public float speedEnemy;
    }

    [Serializable]
    public class FireByteSettingManagerRun
    {
        public GameCore.GameSettingData gameSetting = new GameCore.GameSettingData();
    }

    public FireByteSettingManagerRun ReadManagerSetting()
    {
        GameSettingManager gameSettingData = new GameSettingManager();
        gameSettingData = Resources.Load("GameSettingManager") as GameSettingManager;

        FireByteSettingManagerRun settings = new FireByteSettingManagerRun();
        settings.gameSetting = gameSettingData.gameSetting;
        return settings;
    }
}
