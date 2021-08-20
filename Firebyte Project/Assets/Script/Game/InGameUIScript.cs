using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIScript : MonoBehaviour
{
    [Header("In Game UI")]
    public TMP_Text counterStartText;
    public TMP_Text counterLevetText;
    public Image distanceImage;
    public WinnerUIScript winnerUI;
    public LoseUIScript loseUI;

    

    public void Start()
    {
        GamePlayManagerScript.instance.OnWinGame -= OnWinGame;
        GamePlayManagerScript.instance.OnWinGame += OnWinGame;

        GamePlayManagerScript.instance.OnLoseGame -= OnLoseGame;
        GamePlayManagerScript.instance.OnLoseGame += OnLoseGame;
    }

    private void Update()
    {
        distanceImage.fillAmount = (Mathf.Lerp(0, 1, Mathf.InverseLerp(GamePlayManagerScript.instance.startLine.position.z, GamePlayManagerScript.instance.finishLine.position.z, GamePlayManagerScript.instance.player.transform.position.z)));
    }

    private void OnLoseGame()
    {
        loseUI.gameObject.SetActive(true);
    }

    private void OnWinGame()
    {
        Invoke(nameof(ShowWinUI), 3);       
    }

    private void ShowWinUI()
    {
        winnerUI.gameObject.SetActive(true);
    }
}
