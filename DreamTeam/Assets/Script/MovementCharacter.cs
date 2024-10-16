using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] private Animator animatotor;
    public float speed = 5.0f; // Vitesse de déplacement
    private Vector2 moveDirection;
    private Vector2 movePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Vector3 newPosition = targetPosition + new Vector3(0, 1, 0);
        //    if (CheckTagAtPosition(newPosition, "Sol"))
        //    {
        //        targetPosition = newPosition;
        //    }
        //}

        //transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        bool moveYplus = Input.GetKeyDown(KeyCode.Z);
        bool moveYmoins = Input.GetKeyDown(KeyCode.S);
        bool moveXmoins = Input.GetKeyDown(KeyCode.Q);
        bool moveXplus = Input.GetKeyDown(KeyCode.D);

        if (moveYplus)
        {
            movePosition = new Vector2(0, 1);
            movePosition = new Vector2(0, 1);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    //bool CheckTagAtPosition(Vector3 position, string tag)
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(position, Vector3.down, out hit))
    //    {
    //        if (hit.collider.CompareTag(tag))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}
