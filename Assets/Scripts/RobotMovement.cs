using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    // public Transform robotTransform;
    public Rigidbody2D robotRigidbody;
    public BoxCollider2D boxCollider;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        disableCollisions();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void moveRobot(Vector2 movement)
    {
        robotRigidbody.MovePosition(robotRigidbody.position + movement * speed * Time.fixedDeltaTime);
    }

    public void disableCollisions()
    {
        // robotRigidbody.enabled = false;
        boxCollider.enabled = false;
    }
    public void enableCollisions()
    {
        // robotRigidbody.enabled = false;
        boxCollider.enabled = true;
    }

}
