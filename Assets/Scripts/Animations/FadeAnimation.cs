using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeAnimation : BaseTweenAnimation
    {
        [Header("Events")]
        [SerializeField] private UnityEvent onFadeCompleted;
        
        [Header("Settings")]
        [SerializeField] private bool isFadeOnStart;
        
        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            if (isFadeOnStart)
            {
                StartAnimationWithLoop();
            }
        }
        
        public void StartFading()
        {
            _tween = _canvasGroup.DOFade(0f, duration)
                .SetEase(easeType)
                .OnComplete(UpdateCompletedFade);
        }

        private void StartAnimationWithLoop()
        {
            _tween = _canvasGroup.DOFade(0f, duration)
                .SetEase(easeType)
                .SetLoops(-1, LoopType.Yoyo)
                .OnComplete(UpdateCompletedFade);
        }
        
        private void UpdateCompletedFade()
        {
            gameObject.SetActive(false);
            onFadeCompleted?.Invoke();
        }
    }
}