using DG.Tweening;
using UnityEngine;

namespace Fish
{
    public class FishMovement : MonoBehaviour
    {
        [HideInInspector] public string rarity;
        public GameObject hookedFishPrefab;

        private SpriteRenderer _fishSprite;
        private Tween _tween, _tween2;
    
        private void Start()
        {
            _fishSprite = GetComponentInChildren<SpriteRenderer>();
            ScriptedMovement();
            DOTween.SetTweensCapacity(1250,100);
        }
        private void ScriptedMovement()
        {
            _tween = gameObject.transform.DOMoveX(2f, Random.Range(1.5f, 3f)).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnStepComplete(() =>
            {
                _fishSprite.flipX = !_fishSprite.flipX;
            });
        
            _tween2=gameObject.transform.DOMoveY(transform.position.y + Random.Range(0.5f, 1.5f), Random.Range(.75f, 1.5f)).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
        }
        private void OnDestroy()
        {
            _tween.Kill();
            _tween2.Kill();
        }
    }
}
