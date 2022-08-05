using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fish
{
    public class HookedFishMovement : MonoBehaviour
    {
        [SerializeField] private GameObject collectedFishPrefab;
        
        private string _collectedFishRarity;
        private Tween _tween;
        private void Start()
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -15));
            FishRotate();
        }
        void FishRotate()
        {
            _tween = gameObject.transform.DORotate(new Vector3(0, 0, 15), Random.Range(0.5F, 2)).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("SurfaceLine")) return;
            Instantiate(collectedFishPrefab, gameObject.transform.position, Quaternion.identity,
                transform.parent);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }
    }
}
