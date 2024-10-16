using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 2.0f;  // Vitesse de d�filement
    public bool scrollHorizontally = true;  // D�finit si la cam�ra d�file horizontalement
    public bool scrollVertically = false;   // D�finit si la cam�ra d�file verticalement

    void Update()
    {
        Vector3 newPosition = transform.position;

        // Si on veut scroller horizontalement
        if (scrollHorizontally)
        {
            newPosition.x += scrollSpeed * Time.deltaTime;
        }

        // Si on veut scroller verticalement
        if (scrollVertically)
        {
            newPosition.y += scrollSpeed * Time.deltaTime;
        }

        // Met � jour la position de la cam�ra
        transform.position = newPosition;
    }
}

