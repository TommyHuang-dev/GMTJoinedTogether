using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotMovement : MonoBehaviour
{
    public Rigidbody2D robotRigidbody;
    public GameManagerScript gameManager;
    public float speed;

    BoxCollider2D boxCollider;
    public RobotView robotView;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void moveRobot(Vector2 movement)
    {
        robotRigidbody.MovePosition(robotRigidbody.position + movement * speed * Time.fixedDeltaTime);
    }




}
