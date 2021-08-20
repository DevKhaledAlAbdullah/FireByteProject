using DG.Tweening;
using UnityEngine;

public class MainUIScript : MonoBehaviour
{
    [Header("Tutorial Hand")]
    public Transform handTutorialImage;
    public Transform rightTutorialTarget;
    public Transform leftTutorialTarget;
    public float speedHandTutorial = 1;
   

    /// <summary>
    /// sequance for animation tutorial
    /// </summary>
    private Sequence Seq;

    void Start()
    {
        AnimationHandTutorial();

        GameManager.instance.mainCanvas.gameObject.SetActive(false);        
    }

    /// <summary>
    /// Call this funcation from touch UI to start Game.
    /// </summary>
    public void OnClickStartGame()
    {
        //GameManager.instance.soundManager.ButtonSound.Play();
        GamePlayManagerScript.instance.GameStart();
        GamePlayManagerScript.instance.inGameUI.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        Seq.Pause();
        DOTween.KillAll();
    }

    public void AnimationHandTutorial()
    {
        Seq = DOTween.Sequence();
        Seq.AppendCallback(() =>
        {
            handTutorialImage.DOMove(rightTutorialTarget.position, speedHandTutorial);
        })
        .AppendInterval(speedHandTutorial)
        .AppendCallback(() =>
        {
            handTutorialImage.DOMove(leftTutorialTarget.position, speedHandTutorial);
        })
        .AppendInterval(speedHandTutorial)
        .SetLoops(6);
    }
}
