using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectCanvas : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        Animate();
    }

    private void Animate()
    {
        Sequence mySequence = DOTween.Sequence();
        // Add a movement tween at the beginning
        mySequence.Append(transform.DOMoveY(transform.position.y + 3f, .6f));
        mySequence.Append(canvasGroup.DOFade(0, 0.2f));
        mySequence.Play();
    }
}
