using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public abstract class BaseTweenAnimation : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Min(0f)] protected float duration = 1f;
        
        protected Tween _tween;

        private void OnDisable()
        {
            StopTween();
        }
		
        protected void StopTween()
        {
            if (_tween != null && _tween.IsActive())
            {
                _tween.Kill();
            }
        }
    }
}