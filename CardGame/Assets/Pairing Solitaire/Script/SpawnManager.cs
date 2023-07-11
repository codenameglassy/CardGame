using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<GameObject> spawnableItems = new List<GameObject>();
    public int numberOfCardsToSpawn;
    public float spawnDelay;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Invoke("SpawnCads", 1f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<SceneLoader>().LoadScene("NewMainMenu");
        }

    }

    void SpawnCads()
    {
        numberOfCardsToSpawn = LevelData.instance.myGoalData.numberOfCardsToSpawn;
        spawnableItems.AddRange(LevelData.instance.myGoalData.spawnableItems);
        StartCoroutine(SpawnItemsWithDelay(numberOfCardsToSpawn, spawnDelay));
    }

    IEnumerator SpawnItemsWithDelay(int spawnCount, float delay)
    {
        int spawnedCount = 0;
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnRandomItem();
            spawnedCount++;
            yield return new WaitForSeconds(delay);

            if (spawnedCount >= spawnCount)
            {
                Invoke("StartGame", 1f);
            }
        }

 
    }

    public void StartGame()
    {
        GameManager.instance.hasGameStarted = true;
        GameManager.instance.GameStarter();
        Debug.Log("Game has started");
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

