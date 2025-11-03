using System.Collections;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject obstaclePrefab;

    private int spawnCount;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        while (true) {
            Instantiate(obstaclePrefab, GetRandomPosition(), Quaternion.identity);
            spawnCount++;
            DecreaseSpawnTime();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void DecreaseSpawnTime() {
        if (spawnCount % 5 == 0)
        {
            spawnTime -= 2f;
            if (spawnTime < 0.6f) {
                spawnTime = 0.6f;
            }
        }
    }

    private Vector2 GetRandomPosition() {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector2 randomPosition = new Vector2(transform.position.x, randomHeight);
        return randomPosition;
    }

    public void StopSpawn() {
        StopAllCoroutines();
    }
}
