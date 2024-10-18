using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementCharacter : MonoBehaviour
{
    public static MovementCharacter Instance { get; private set; }


    public Animator animatotor;
    public GameObject chara;
    public Tilemap tilemap;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public Tilemap cloudtilemap;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public Tilemap cloudtilemapmouvante;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public Tilemap cloudtilemapmouvante2;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public float moveSpeed = 5f;  // Vitesse de d�placement
    public Vector3Int playerGridPosition;  // Position du joueur dans la grille
    public float destructionDelay = 1f;

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
        // Initialiser la position du joueur sur la grille au d�but du jeu
        playerGridPosition = tilemap.WorldToCell(transform.position);
    }

    void Update()
    {
        // Appeler la fonction pour g�rer les mouvements du joueur
        HandleMovement();
    }

    void HandleMovement()
    {
        // Variables pour suivre le d�placement du joueur
        Vector3Int newGridPosition = playerGridPosition;

        // G�rer les entr�es de clavier (par exemple, fl�ches directionnelles ou ZQSD)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newGridPosition += new Vector3Int(0, 1, 0);  // D�placement vers le haut
            chara.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newGridPosition += new Vector3Int(0, -1, 0);  // D�placement vers le bas
            chara.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newGridPosition += new Vector3Int(-1, 0, 0);  // D�placement vers la gauche
            chara.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newGridPosition += new Vector3Int(1, 0, 0);  // D�placement vers la droite
            chara.transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        // V�rifier si la nouvelle position est valide (tuile existante et traversable)
        TileBase tileAtNewPosition = tilemap.GetTile(newGridPosition);

        if (tileAtNewPosition != null)  // Si la tuile existe
        {
            // Convertir la position de la grille en position du monde
            Vector3 newWorldPosition = tilemap.CellToWorld(newGridPosition);

            // D�placer le joueur
            transform.position = newWorldPosition;

            // Mettre � jour la position du joueur dans la grille
            playerGridPosition = newGridPosition;
        }
        else
        {
            tileAtNewPosition = cloudtilemap.GetTile(newGridPosition);

            if (tileAtNewPosition != null)  // Si la tuile existe
            {
                // Convertir la position de la grille en position du monde
                Vector3 newWorldPosition = cloudtilemap.CellToWorld(newGridPosition);

                // D�placer le joueur
                transform.position = newWorldPosition;

                // Mettre � jour la position du joueur dans la grille
                playerGridPosition = newGridPosition;
            }
            else
            {
                tileAtNewPosition = cloudtilemapmouvante.GetTile(newGridPosition);

                if (tileAtNewPosition != null)  // Si la tuile existe
                {
                    // Convertir la position de la grille en position du monde
                    Vector3 newWorldPosition = cloudtilemapmouvante.CellToWorld(newGridPosition);

                    // D�placer le joueur
                    transform.position = newWorldPosition;

                    // Mettre � jour la position du joueur dans la grille
                    playerGridPosition = newGridPosition;
                }
                else
                {
                    tileAtNewPosition = cloudtilemapmouvante2.GetTile(newGridPosition);

                    if (tileAtNewPosition != null)  // Si la tuile existe
                    {
                        // Convertir la position de la grille en position du monde
                        Vector3 newWorldPosition = cloudtilemapmouvante2.CellToWorld(newGridPosition);

                        // D�placer le joueur
                        transform.position = newWorldPosition;

                        // Mettre � jour la position du joueur dans la grille
                        playerGridPosition = newGridPosition;
                    }
                    else
                    {
                        // Si la case est vide ou non traversable, on ne d�place pas le joueur
                        Debug.Log("Tuile non traversable ou inexistante !");
                        MoveToNewPosition(tilemap, newGridPosition);  // D�placer sur la tuile vide
                        StartCoroutine(DestroyAfterDelay());  // D�truire apr�s un d�lai
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bird") || other.CompareTag("Vent"))
        {
            Vector3Int newGridPosition = playerGridPosition;
            newGridPosition += new Vector3Int(1, 0, 0);
            TileBase tileAtNewPosition = tilemap.GetTile(newGridPosition);

            if (tileAtNewPosition != null)
            {
                Vector3 newWorldPosition = tilemap.CellToWorld(newGridPosition);
                transform.position = newWorldPosition;
                playerGridPosition = newGridPosition;
            }
            else
            {
                tileAtNewPosition = cloudtilemap.GetTile(newGridPosition);

                if (tileAtNewPosition != null)
                {
                    Vector3 newWorldPosition = cloudtilemap.CellToWorld(newGridPosition);
                    transform.position = newWorldPosition;
                    playerGridPosition = newGridPosition;
                }
                else
                {
                    Debug.Log("Tuile non traversable ou inexistante !");
                    MoveToNewPosition(tilemap, newGridPosition);
                    StartCoroutine(DestroyAfterDelay());
                }
            }
            Destroy(other.gameObject);
            Spawner.Instance.alreadySpawn = false;
        }
    }

    void MoveToNewPosition(Tilemap map, Vector3Int newGridPosition)
    {
        // Convertir la position de la grille en position du monde
        Vector3 newWorldPosition = map.CellToWorld(newGridPosition);
        animatotor.SetTrigger("Jump");

        // D�placer le joueur
        transform.position = newWorldPosition;

        // Mettre � jour la position du joueur dans la grille
        playerGridPosition = newGridPosition;
    }

    IEnumerator DestroyAfterDelay()
    {
        // Optionnel : jouer une animation ou d�clencher une action avant la destruction
        animatotor.SetTrigger("Dead");

        // Attendre un certain temps avant la destruction
        yield return new WaitForSeconds(destructionDelay);

        // D�truire le joueur
        Destroy(gameObject);
    }
}
