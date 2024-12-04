using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClothingSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> prefabToSpawn = new List<GameObject>();
    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField] float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField] float maxTimeBetweenSpawns = 1.0f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")]
    [SerializeField] float maxXDistance = 1.5f;
    [SerializeField] Transform parentOfAllInstances;

    void Start()
    {
        SpawnRoutine();
    }

    async void SpawnRoutine()
    {
        while (true)
        {
            if (prefabToSpawn.Count == 0)
            {
                Debug.LogWarning("No prefabs to spawn.");
                break; // Break the loop if there are no prefabs to spawn
            }

            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds); // co-routines
            if (!this) break; // might be destroyed when moving to a new scene

            int rand = Random.Range(0, prefabToSpawn.Count); // Valid index now assured
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn[rand], positionOfSpawnedObject, Quaternion.identity);
            newObject.transform.parent = parentOfAllInstances;
        }
    }
}