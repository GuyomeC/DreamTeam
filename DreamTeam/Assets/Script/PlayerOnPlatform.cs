using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private Transform originalParent;  // Garde une référence à son parent d'origine

    void Start()
    {
        // On enregistre le parent d'origine
        originalParent = transform.parent;
    }

    private void Update()
    {
        originalParent = transform.parent;

    }

    // Lorsque le personnage entre en contact avec la plateforme
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // On attache le personnage à la plateforme
            transform.parent = collision.transform;
        }
        
        if (collision.gameObject.CompareTag("MovingPlatform2"))
        {
            // On attache le personnage à la plateforme
            transform.parent = collision.transform;
        }
    }

    // Lorsque le personnage quitte la plateforme
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // On le détache de la plateforme et revient à l'état normal
            transform.parent = originalParent;
        }

        if (collision.gameObject.CompareTag("MovingPlatform2"))
        {
            // On attache le personnage à la plateforme
            transform.parent = originalParent;
        }
    }
}
