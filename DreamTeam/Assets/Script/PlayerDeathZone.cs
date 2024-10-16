using UnityEngine;

public class PlayerDeathZone : MonoBehaviour
{
    // Cette fonction est appelée lorsque le joueur sort d'une zone définie par un Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // Vérifie si le joueur a quitté la zone
        if (other.CompareTag("GameZone"))
        {
            // Appelle la fonction de mort
            Die();
        }
    }

    // Fonction appelée quand le joueur meurt
    void Die()
    {
        // Pour l'instant, on affiche un message, mais ici tu peux ajouter tout le comportement lié à la mort du joueur
        Debug.Log("Le joueur est mort en quittant la zone !");

        // Exemple de destruction du joueur
        Destroy(gameObject);

        // Tu peux aussi ajouter ici un écran de Game Over, réinitialiser la scène, etc.
    }
}
