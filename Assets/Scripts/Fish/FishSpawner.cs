using System.Collections.Generic;
using UnityEngine;

namespace Fish
{
    public class FishSpawner : MonoBehaviour
    {
        [SerializeField] Transform prefabParent;
    
        public List<FishSO> fishData;

        private Vector3 _spawnLocation;

        private void Start()
        {
            SpawnFish();
        }

        void SpawnFish()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j =0; j > -201; j-=4)
                {
                    GameObject fish;
                    int randomNumber;
                    SpawnLocation(j);
                    var diceRoll = RollDice();
                    if (diceRoll < 81)
                    {
                        randomNumber = Random.Range(0, 6);
                        fish = Instantiate(fishData[randomNumber].fishPrefab, _spawnLocation, Quaternion.identity, prefabParent);
                    }
                    else if(diceRoll<96)
                    {
                        randomNumber = Random.Range(6, 8);
                        fish = Instantiate(fishData[randomNumber].fishPrefab, _spawnLocation, Quaternion.identity, prefabParent);
                    }
                    else
                    {
                        randomNumber = 8;
                        fish = Instantiate(fishData[randomNumber].fishPrefab, _spawnLocation, Quaternion.identity, prefabParent);
                    }
                    fish.GetComponent<FishMovement>().rarity = fishData[randomNumber].rarity;
                } 
            }
        }

        private int RollDice()
        {
            return Random.Range(1, 101);
        }

        private void SpawnLocation(int j)
        {
            _spawnLocation = new Vector3(-2f, j + Random.Range(-1f,1f), 0);
        }

    }
}
