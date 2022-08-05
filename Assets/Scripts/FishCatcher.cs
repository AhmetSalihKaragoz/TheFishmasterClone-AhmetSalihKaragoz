using System.Collections.Generic;
using Fish;
using UnityEngine;

public class FishCatcher : MonoBehaviour
{
    public Transform jointPoint;
    [SerializeField] private LevelManager levelManager;
    [HideInInspector] public List<GameObject> catchList = new List<GameObject>();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Fish")) return;
        var fishMovement = collision.GetComponent<FishMovement>();
        if (catchList.Count < levelManager.currentStrength)
        {
            Destroy(collision.gameObject);
            Instantiate(fishMovement.hookedFishPrefab, jointPoint.position, Quaternion.identity, gameObject.transform);
            catchList.Add(fishMovement.hookedFishPrefab);

        }
    }

}
