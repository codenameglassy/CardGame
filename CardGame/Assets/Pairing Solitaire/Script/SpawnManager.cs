using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnableItems = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnItemsWithDelay(36, 0.15f));
    }

    IEnumerator SpawnItemsWithDelay(int spawnCount, float delay)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnRandomItem();

            yield return new WaitForSeconds(delay);

            if ( spawnCount==0)
            {
                GameManager.instance.hasGameStarted = true;
            }
        }

 
    }

    void SpawnRandomItem()
    {
        if (spawnableItems.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnableItems.Count);
            GameObject spawnedItem = Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);
            spawnableItems.RemoveAt(randomIndex);
            
        }
    }
   
}

