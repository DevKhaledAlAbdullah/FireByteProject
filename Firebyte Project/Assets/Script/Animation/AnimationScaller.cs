using DG.Tweening;
using UnityEngine;

public class AnimationScaller : MonoBehaviour
{
    private float duration = 0.5f;


    void Start()
    {
        Animation();
    }

    void Animation()
    {
        Sequence Seq = DOTween.Sequence();

        Seq.AppendCallback(() =>
        {
            transform.DOScale(1.1f, duration);
        })
        .AppendInterval(duration)
        .AppendCallback(() => {
            transform.DOScale(1f, duration);
        })
        .AppendInterval(duration).OnComplete(() => {
            if (this.gameObject.activeInHierarchy)
                Seq.Restart();
        });
    }
}
