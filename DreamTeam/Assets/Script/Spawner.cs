using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject attentionSignPrefab;  // Prefab du panneau d'attention à afficher avant le spawn
    public GameObject enemyPrefab;  // Prefab de l'ennemi à spawner après la prévisualisation
    public float spawnDelay = 1f;  // Délai avant le spawn (1 seconde)
    public float moveSpeed = 2f;  // Vitesse de déplacement de l'ennemi

    public int maxInvokeDelay = 25;
    public int minInvokeDelay = 20;

    private GameObject attentionSign;  // Référence à l'instance du panneau d'attention

    void Start()
    {
        InvokeRepeating("StartSpawnEnemy", 0f, UnityEngine.Random.Range(minInvokeDelay, maxInvokeDelay));
    }

    void Update()
    {
        
    }

    void StartSpawnEnemy()
    {
        // Lancer la coroutine de spawn de l'ennemi
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + 5);
        attentionSign = Instantiate(attentionSignPrefab, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);
        Destroy(attentionSign);
        Vector3 spawnPositionEnemy = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPositionEnemy, Quaternion.identity);

        StartCoroutine(MoveEnemy(spawnedEnemy));
    }

    IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (enemy.transform.position.x >= 11)
            {
                Destroy(enemy);
            }
            yield return null;
        }
    }
}
