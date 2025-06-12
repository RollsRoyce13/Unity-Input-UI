using System;
using DG.Tweening;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeAnimation : BaseTweenAnimation
    {
        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            _tween = _canvasGroup.DOFade(0f, duration)
                .SetEase(easeType)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}