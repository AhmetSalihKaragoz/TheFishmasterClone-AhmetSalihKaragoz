using UnityEngine;

namespace Fish
{
    [CreateAssetMenu(fileName ="Fish", menuName = "Fishes")]
    public class FishSO : ScriptableObject
    {
        public new string name;
        public string rarity;

        public GameObject fishPrefab;

        public int value;
    }
}
