using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fish
{
    public class CollectedFishMovement : MonoBehaviour
    {
        public int collectedFishPrice;
        
        private readonly Vector3 _jumpPos1 = new Vector3(0, 14, -2.5f);
        private readonly Vector3 _jumpPos2 = new Vector3(1.6f, 14, -2.5f);
        private Tween _tween;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("JumpLine")) return;
            GetComponent<Rigidbody2D>().AddTorque(Random.Range(0.5f, 3f)*Random.Range(-1,2),ForceMode2D.Impulse);
            var randomJumpPoint = new Vector3(Random.Range(_jumpPos1.x, _jumpPos2.x), Random.Range(_jumpPos1.y, _jumpPos2.y), 0);
            _tween = gameObject.transform.DOJump(randomJumpPoint, 3.25f, 1, 1f).OnComplete(() =>
            {
                CurrencyManager.Instance.IncreaseCurrency(collectedFishPrice);
                Destroy(gameObject);
                });
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }
    }
}
