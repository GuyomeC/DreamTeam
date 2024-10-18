using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private Transform originalParent;  // Garde une r�f�rence � son parent d'origine

    void Start()
    {
        // On enregistre le parent d'origine
        originalParent = transform.parent;
    }

    // Lorsque le personnage entre en contact avec la plateforme
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // On attache le personnage � la plateforme
            transform.parent = collision.transform;
        }
    }

    // Lorsque le personnage quitte la plateforme
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // On le d�tache de la plateforme et revient � l'�tat normal
            transform.parent = originalParent;
        }
    }
}
