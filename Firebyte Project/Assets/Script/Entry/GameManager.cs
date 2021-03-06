using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static GameManager instance;

    [Header("UI")]
    public Image initializerImage;
    public Image logoImage;
    public TMP_Text initializeText;
    public Transform mainCanvas;
    public GameCore.FireByteSettingManagerRun GameSettingManager = new GameCore.FireByteSettingManagerRun();
    /// <summary>
    /// usefull to create Actions inside our script.
    /// </summary>
    public delegate void Callback();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //To slider initalizer we can use it when we connect by APIs
        initializerImage.DOFillAmount(1 , 2.5f).OnComplete(TriggerGameScene);
        GameCore core = new GameCore();
        GameSettingManager = core.ReadManagerSetting();
    }

   

    private void TriggerGameScene()
    {
        SceneManager.LoadScene(MetaData.ConstVariable.Scene.GameScene, LoadSceneMode.Single);        
    }
}
