using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 2.0f;  // Vitesse de d�filement
    public bool scrollHorizontally = true;  // D�finit si la cam�ra d�file horizontalement
    public bool scrollVertically = false;   // D�finit si la cam�ra d�file verticalement

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

