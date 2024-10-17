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
        // Lancer la s�quence de spawn d�s le d�but (ou tu peux appeler SpawnEnemy() quand tu veux)
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        // �tape 1 : Afficher le panneau d'attention
        attentionSign = Instantiate(attentionSignPrefab, transform.position, Quaternion.identity);

        // Attendre 1 seconde (ou la dur�e d�finie dans spawnDelay)
        yield return new WaitForSeconds(spawnDelay);

        // D�truire le panneau d'attention apr�s 1 seconde
        Destroy(attentionSign);

        // �tape 2 : Faire appara�tre l'ennemi
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Lancer le mouvement de l'ennemi
        StartCoroutine(MoveEnemy(spawnedEnemy));
    }

    IEnumerator MoveEnemy(GameObject enemy)
    {
        // Tant que l'ennemi existe, il se d�place de gauche � droite
        while (enemy != null)
        {
            // D�placer l'ennemi vers la droite
            enemy.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
