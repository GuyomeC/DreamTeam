using UnityEngine;

public class PlayerDeathZone : MonoBehaviour
{
    // Cette fonction est appel�e lorsque le joueur sort d'une zone d�finie par un Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // V�rifie si le joueur a quitt� la zone
        if (other.CompareTag("GameZone"))
        {
            // Appelle la fonction de mort
            Die();
        }
    }

    // Fonction appel�e quand le joueur meurt
    void Die()
    {
        // Pour l'instant, on affiche un message, mais ici tu peux ajouter tout le comportement li� � la mort du joueur
        Debug.Log("Le joueur est mort en quittant la zone !");

        // Exemple de destruction du joueur
        Destroy(gameObject);

        // Tu peux aussi ajouter ici un �cran de Game Over, r�initialiser la sc�ne, etc.
    }
}
