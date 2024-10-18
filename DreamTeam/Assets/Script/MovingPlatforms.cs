using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingPlatforms : MonoBehaviour
{
    public float speed = 2f; // Vitesse de d�placement
    [SerializeField, Range(0.1f, 50f)] private float limiteDroite = 1f;
    [SerializeField, Range(0.1f, 50f)] private float limiteGauche = 1f;
    private Vector3 limiteDroitePosition;
    private Vector3 limiteGauchePosition;
    public float distance = 3f; // Distance du mouvement
    private Vector3 startPosition;
    private bool movingRight = true;
    public bool Reverse = false;

    void Start()
    {
        // Enregistrer la position de d�part
        startPosition = transform.position;
        limiteDroitePosition = transform.position + new Vector3(limiteDroite, 0, 0);
        limiteGauchePosition = transform.position - new Vector3(limiteGauche, 0, 0);
    }

    void Update()
    {

        Vector3Int gridPosition = MovementCharacter.Instance.playerGridPosition;

        if (movingRight)
        {
            if (IsOdd(gridPosition.y)) 
                transform.position += Vector3.right * speed * Time.deltaTime;
            else  // Si on veut inverser, bouger � gauche
                transform.position += Vector3.left * speed * Time.deltaTime;

            // Inverser si limite atteinte
            if (transform.position.x >= limiteDroitePosition.x || transform.position.x <= limiteGauchePosition.x)
            {
                movingRight = false;
            }
        }
        else
        {
            if (!IsOdd(gridPosition.y))  // Si on ne veut pas inverser
                transform.position += Vector3.left * speed * Time.deltaTime;
            else  // Si on veut inverser, bouger � droite
                transform.position += Vector3.right * speed * Time.deltaTime;

            // Inverser si limite atteinte
            if (transform.position.x <= limiteGauchePosition.x || transform.position.x >= limiteDroitePosition.x)
            {
                movingRight = true;
            }
        }
    }

    private bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    //Cette fonction sert a visualiser le chemin de l'ennemi dans l'�diteur
    void OnDrawGizmos()
    {
        if (!Application.IsPlaying(gameObject))
        {
            limiteDroitePosition = transform.position + new Vector3(limiteDroite, 0, 0);
            limiteGauchePosition = transform.position - new Vector3(limiteGauche, 0, 0);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawCube(limiteDroitePosition, new Vector3(0.2f, 1, 0.2f));
        Gizmos.DrawCube(limiteGauchePosition, new Vector3(0.2f, 1, 0.2f));
        Gizmos.DrawLine(limiteDroitePosition, limiteGauchePosition);
    }
}
