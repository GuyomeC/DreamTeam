using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 2.0f;  // Vitesse de défilement
    public bool scrollHorizontally = true;  // Définit si la caméra défile horizontalement
    public bool scrollVertically = false;   // Définit si la caméra défile verticalement

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

        // Met à jour la position de la caméra
        transform.position = newPosition;
    }
}

