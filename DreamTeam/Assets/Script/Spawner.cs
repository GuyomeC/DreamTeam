using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject attentionSignPrefab;  // Prefab du panneau d'attention � afficher avant le spawn
    public GameObject enemyPrefab;  // Prefab de l'ennemi � spawner apr�s la pr�visualisation
    public float spawnDelay = 1f;  // D�lai avant le spawn (1 seconde)
    public float moveSpeed = 2f;  // Vitesse de d�placement de l'ennemi

    private GameObject attentionSign;  // R�f�rence � l'instance du panneau d'attention

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
