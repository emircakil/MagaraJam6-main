using System;
using UnityEngine;
using DG.Tweening;


public class FinalVignet : MonoBehaviour
{
    [SerializeField] private Q_Vignette_Split _qVignetteSplit;
    private int healt = 100;
    [SerializeField] private float duration = 2f;
    private float minValue = 0f, maxValue = 50f;

    private void Start()
    {
        ResetVinyet();
    }

    private void ResetVinyet()
    {
        DOTween.To(() => _qVignetteSplit.mainScale, x =>
        {
            _qVignetteSplit.mainScale = x;
            _qVignetteSplit.skyScale = x;
        }, minValue, duration).
            OnComplete(() => DOTween.Sequence(2f).OnComplete(()=> Application.Quit()));
    }
}