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
        // Lancer la séquence de spawn dès le début (ou tu peux appeler SpawnEnemy() quand tu veux)
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        // Étape 1 : Afficher le panneau d'attention
        attentionSign = Instantiate(attentionSignPrefab, transform.position, Quaternion.identity);

        // Attendre 1 seconde (ou la durée définie dans spawnDelay)
        yield return new WaitForSeconds(spawnDelay);

        // Détruire le panneau d'attention après 1 seconde
        Destroy(attentionSign);

        // Étape 2 : Faire apparaître l'ennemi
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Lancer le mouvement de l'ennemi
        StartCoroutine(MoveEnemy(spawnedEnemy));
    }

    IEnumerator MoveEnemy(GameObject enemy)
    {
        // Tant que l'ennemi existe, il se déplace de gauche à droite
        while (enemy != null)
        {
            // Déplacer l'ennemi vers la droite
            enemy.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
