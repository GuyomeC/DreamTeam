using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementCharacter : MonoBehaviour
{
    public Animator animatotor;
    public Tilemap tilemap;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public Tilemap cloudtilemap;  // R�f�rence � la Tilemap (� lier dans l'Inspector)
    public float moveSpeed = 5f;  // Vitesse de d�placement
    private Vector3Int playerGridPosition;  // Position du joueur dans la grille
    public float destructionDelay = 1f;

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
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newGridPosition += new Vector3Int(0, -1, 0);  // D�placement vers le bas
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newGridPosition += new Vector3Int(-1, 0, 0);  // D�placement vers la gauche
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newGridPosition += new Vector3Int(1, 0, 0);  // D�placement vers la droite
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
                // Si la case est vide ou non traversable, on ne d�place pas le joueur
                Debug.Log("Tuile non traversable ou inexistante !");
                MoveToNewPosition(tilemap, newGridPosition);  // D�placer sur la tuile vide
                StartCoroutine(DestroyAfterDelay());  // D�truire apr�s un d�lai
            }
        }
    }

    void MoveToNewPosition(Tilemap map, Vector3Int newGridPosition)
    {
        // Convertir la position de la grille en position du monde
        Vector3 newWorldPosition = map.CellToWorld(newGridPosition);

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
