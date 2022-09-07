using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectCanvas : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    public TextMeshProUGUI Text;
    public float TargetDistanceUp = 2.5f;
    public float MovingUpDuration = .3f;
    public float FadeDuration = .1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetTextColor(Color targetColor)
    {
        Text.color = targetColor;
    }

    public void Animate(string text)
    {
        Text.text = text;
        Animate();
    }

    private void Animate()
    {
        Sequence mySequence = DOTween.Sequence();
        // Add a movement tween at the beginning
        mySequence.Append(transform.DOMoveY(transform.position.y + TargetDistanceUp, MovingUpDuration));
        mySequence.Append(canvasGroup.DOFade(0, FadeDuration));
        mySequence.OnComplete(() => Destroy(gameObject));
        mySequence.Play();
    }
}
