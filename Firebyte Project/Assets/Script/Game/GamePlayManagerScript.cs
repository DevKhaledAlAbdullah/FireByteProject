using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GamePlayManagerScript : MonoBehaviour
{
    public static GamePlayManagerScript instance;

    [Header("In Game UI")]
    public InGameUIScript inGameUI;
    public int indexLevel;


    [Header("In Game Objects")]
    public CharacterController player;
    public Transform startLine;
    public Transform finishLine;

    [Header("In Partical System")]
    public ParticleSystem fireRedParticle;
    public ParticleSystem firePurpleParticle;
    public ParticleSystem fullDieParticle;

    public GameManager.Callback OnStartGame;
    public GameManager.Callback OnLoseGame;
    public GameManager.Callback OnWinGame;

    public List<GameObject> Levels;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        indexLevel = PlayerPrefs.GetInt(MetaData.ConstVariable.GameSetting.IndexLevel);
        inGameUI.counterLevetText.text = string.Format("{0} {1}" , MetaData.ConstVariable.GameSetting.Level ,  (indexLevel+1).ToString());
        if (indexLevel >= Levels.Count)
        {
            indexLevel = 0;
            PlayerPrefs.SetInt(MetaData.ConstVariable.GameSetting.IndexLevel, 0);
        }

        Instantiate(Levels[indexLevel], transform.parent);
    }

  
    public void Win()
    {
        indexLevel++;
        PlayerPrefs.SetInt(MetaData.ConstVariable.GameSetting.IndexLevel, indexLevel);
      
       
        if (OnWinGame != null)
            OnWinGame();
    }

    public void Lose()
    {
        PlayerPrefs.SetInt(MetaData.ConstVariable.GameSetting.IndexLevel, indexLevel);

        if (OnLoseGame != null)
            OnLoseGame();

        
    }
    public void GameStart()
    {
        StartCoroutine(CounterStartGame());
    }

    public IEnumerator CounterStartGame()
    {
        inGameUI.counterStartText.gameObject.SetActive(true);
        inGameUI.counterStartText.text = "1";
        yield return new WaitForSeconds(1);
        inGameUI.counterStartText.text = "2";
        yield return new WaitForSeconds(1);
        inGameUI.counterStartText.text = "3";
        yield return new WaitForSeconds(1);
        inGameUI.counterStartText.text = "GO";
        yield return new WaitForSeconds(0.5f);
        inGameUI.counterStartText.gameObject.SetActive(false);

        if (OnStartGame != null)
            OnStartGame();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GamePlayManagerScript))]
public class GamePlayManagerScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GamePlayManagerScript myScript = (GamePlayManagerScript)target;
        if (GUILayout.Button("Win Level"))
        {
            myScript.Win();
        }

        if (GUILayout.Button("Lose Level"))
        {
            myScript.Lose();
        }
    }
}
#endif
