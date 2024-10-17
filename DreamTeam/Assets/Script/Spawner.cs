using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject attentionSignPrefab;  // Prefab du panneau d'attention à afficher avant le spawn
    public GameObject enemyPrefab;  // Prefab de l'ennemi à spawner après la prévisualisation
    public float spawnDelay = 1f;  // Délai avant le spawn (1 seconde)
    public float moveSpeed = 2f;  // Vitesse de déplacement de l'ennemi

    private GameObject attentionSign;  // Référence à l'instance du panneau d'attention

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        attentionSign = Instantiate(attentionSignPrefab, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);
        Destroy(attentionSign);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

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
