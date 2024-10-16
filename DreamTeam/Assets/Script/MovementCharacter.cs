using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementCharacter : MonoBehaviour
{

    [SerializeField] private Animator animatotor;
    public Tilemap tilemap;  // Référence à la Tilemap (à lier dans l'Inspector)
    public float moveSpeed = 5f;  // Vitesse de déplacement
    private Vector3Int playerGridPosition;  // Position du joueur dans la grille

    void Start()
    {
        // Initialiser la position du joueur sur la grille au début du jeu
        playerGridPosition = tilemap.WorldToCell(transform.position);
    }

    void Update()
    {
        // Appeler la fonction pour gérer les mouvements du joueur
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatotor.SetTrigger("ActiveVent");
        }
    }

    void HandleMovement()
    {
        // Variables pour suivre le déplacement du joueur
        Vector3Int newGridPosition = playerGridPosition;

        // Gérer les entrées de clavier (par exemple, flèches directionnelles ou ZQSD)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newGridPosition += new Vector3Int(0, 1, 0);  // Déplacement vers le haut
            animatotor.SetTrigger("Action");
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newGridPosition += new Vector3Int(0, -1, 0);  // Déplacement vers le bas
            animatotor.SetTrigger("Action");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newGridPosition += new Vector3Int(-1, 0, 0);  // Déplacement vers la gauche
            animatotor.SetTrigger("Action");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newGridPosition += new Vector3Int(1, 0, 0);  // Déplacement vers la droite
            animatotor.SetTrigger("Action");
        }

        // Vérifier si la nouvelle position est valide (tuile existante et traversable)
        TileBase tileAtNewPosition = tilemap.GetTile(newGridPosition);

        if (tileAtNewPosition != null)  // Si la tuile existe
        {
            // Convertir la position de la grille en position du monde
            Vector3 newWorldPosition = tilemap.CellToWorld(newGridPosition);

            // Déplacer le joueur
            transform.position = newWorldPosition;

            // Mettre à jour la position du joueur dans la grille
            playerGridPosition = newGridPosition;
        }
        else
        {
            // Si la case est vide ou non traversable, on ne déplace pas le joueur
            Debug.Log("Tuile non traversable ou inexistante !");
        }
    }
}
