using DG.Tweening;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(RectTransform))]
    public class TextScroller : BaseTweenAnimation
    {
        [SerializeField, Min(0f)] private float delayBeforeScroll = 1f;
        [SerializeField, Min(0f)] private float endYPosition = 1400f;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            ScheduleScrollStart();
        }

        private void ScheduleScrollStart()
        {
            _tween = DOVirtual.DelayedCall(delayBeforeScroll, StartScroll);
        }

        private void StartScroll()
        {
            StopTween();
            
            _tween = _rectTransform.DOAnchorPosY(endYPosition, duration)
                .SetEase(easeType)
                .OnComplete(() => Debug.Log("Credits finished."));
        }
    }
}