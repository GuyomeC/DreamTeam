using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 2.0f;  // Vitesse de défilement
    public bool scrollHorizontally = true;  // Définit si la caméra défile horizontalement
    public bool scrollVertically = false;   // Définit si la caméra défile verticalement

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (scrollVertically && GameManager.Instance.IsPlaying)
        {
            newPosition.y += scrollSpeed * Time.deltaTime;
        }

        transform.position = newPosition;
    }
}

