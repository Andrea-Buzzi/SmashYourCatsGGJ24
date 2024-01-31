using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    private GameObject currentSpawnedObject = null; // Track the current spawned object
    private int lastPrefabIndex = -1; // Track the index of the last spawned prefab

    public GameObject SpawnRandomObject()
    {
        // Destroy the previously spawned object, if any
        if (currentSpawnedObject != null)
        {
            Destroy(currentSpawnedObject);
        }

        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.LogWarning("No prefabs assigned to ObjectSpawner.");
            return null;
        }

        int randomIndex = GetRandomIndexExcludingLast();

        GameObject prefabToSpawn = prefabs[randomIndex];
        currentSpawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation, transform);

        // Assign the winCanvas and loseCanvas to the spawned object if it has an ObjectMovementChecker component
        ObjectMovementChecker checker = currentSpawnedObject.GetComponent<ObjectMovementChecker>();
        if (checker != null)
        {
            checker.winCanvas = winCanvas;
            checker.loseCanvas = loseCanvas;
        }

        // Remember the index of the spawned prefab
        lastPrefabIndex = randomIndex;

        return currentSpawnedObject;
    }

    // Helper method to get a random index different from the last spawned prefab's index
    private int GetRandomIndexExcludingLast()
    {
        if (prefabs.Count == 1) return 0; // Only one option available

        int randomIndex = Random.Range(0, prefabs.Count);
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, prefabs.Count);
        }
        return randomIndex;
    }
}