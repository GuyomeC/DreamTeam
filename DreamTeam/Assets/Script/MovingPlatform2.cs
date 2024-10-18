using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    public float speed = 2f; // Vitesse de déplacement
    [SerializeField, Range(-50f, 0.1f)] private float limiteDroite = -1f;
    [SerializeField, Range(-50f, 0.1f)] private float limiteGauche = -1f;
    private Vector3 limiteDroitePosition;
    private Vector3 limiteGauchePosition;
    public float distance = 3f; // Distance du mouvement
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        // Enregistrer la position de départ
        startPosition = transform.position;
        limiteDroitePosition = transform.position + new Vector3(limiteDroite, 0, 0);
        limiteGauchePosition = transform.position - new Vector3(limiteGauche, 0, 0);
    }

    void Update()
    {
        // Faire bouger la plateforme à gauche et à droite
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            // Si la plateforme atteint la distance maximale, inverser le sens
            if (transform.position.x >= limiteDroite)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            // Si la plateforme atteint la distance minimale, inverser le sens
            if (-transform.position.x >= limiteGauche)
            {
                movingRight = true;
            }
        }
    }

    //Cette fonction sert a visualiser le chemin de l'ennemi dans l'éditeur
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
