using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // R�f�rence � l'Animator
    public string animationTrigger = "PlayAnimation"; // Nom du trigger de l'animation

    void Start()
    {
        // D�marre la coroutine pour activer l'animation toutes les 3 secondes
        StartCoroutine(ActivateAnimation());
    }

    IEnumerator ActivateAnimation()
    {
        while (true) // Boucle infinie
        {
            // Active l'animation
            animator.SetTrigger(animationTrigger);

            // Attend 3 secondes
            yield return new WaitForSeconds(3f);
        }
    }
}
