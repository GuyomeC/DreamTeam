using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    public GameObject attentionSignPrefab;  // Prefab du panneau d'attention à afficher avant le spawn
    public GameObject enemyPrefab;  // Prefab de l'ennemi à spawner après la prévisualisation
    public GameObject attentionSignPrefab2;  // Prefab du panneau d'attention à afficher avant le spawn
    public GameObject enemyPrefab2;  // Prefab de l'ennemi à spawner après la prévisualisation
    public float spawnDelay = 1f;  // Délai avant le spawn (1 seconde)
    public float moveSpeed = 2f;  // Vitesse de déplacement de l'ennemi
    public bool alreadySpawn = false;
    public Animator animator;

    public int maxInvokeDelay = 25;
    public int minInvokeDelay = 20;

    private GameObject attentionSign;  // Référence à l'instance du panneau d'attention

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if(GameManager.Instance.currentScore >= 25)
        {
            InvokeRepeating("StartSpawnEnemy", 0f, UnityEngine.Random.Range(minInvokeDelay, maxInvokeDelay));
        }
    }

    void StartSpawnEnemy()
    {
        if(!alreadySpawn)
            StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int choix = UnityEngine.Random.Range(0, 2);
        int pos_y = UnityEngine.Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(transform.position.x + 2, transform.position.y - pos_y, transform.position.z + 5);
        alreadySpawn = true;

        if(choix == 1)
        {
            attentionSign = Instantiate(attentionSignPrefab2, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
            Destroy(attentionSign);
            Vector3 spawnPositionEnemy = new Vector3(transform.position.x + 2, transform.position.y - pos_y, transform.position.z + 5);
            GameObject spawnedEnemy = Instantiate(enemyPrefab2, spawnPositionEnemy, Quaternion.identity);

            StartCoroutine(Wind(spawnedEnemy));
        }
        else
        {
            attentionSign = Instantiate(attentionSignPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
            Destroy(attentionSign);
            Vector3 spawnPositionEnemy = new Vector3(transform.position.x, transform.position.y - pos_y, transform.position.z + 5);
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPositionEnemy, Quaternion.identity);

            StartCoroutine(MoveEnemy(spawnedEnemy));
        }
    }

    IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (enemy.transform.position.x >= 11)
            {
                Destroy(enemy);
                alreadySpawn = false;
            }
            yield return null;
        }
    }

    IEnumerator Wind(GameObject enemy)
    {
        Animator childRigidbody = enemy.GetComponentInChildren<Animator>();

        childRigidbody.SetTrigger("ActiveVent");
        yield return new WaitForSeconds(1);
        Destroy(enemy);
        alreadySpawn = false;
    }

}