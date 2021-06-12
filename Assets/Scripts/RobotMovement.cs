using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotMovement : MonoBehaviour
{
    public Rigidbody2D robotRigidbody;
    public BoxCollider2D boxCollider;
    public GameManagerScript gameManager;
    public float speed;

    int robotIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void moveRobot(Vector2 movement)
    {
        robotRigidbody.MovePosition(robotRigidbody.position + movement * speed * Time.fixedDeltaTime);
    }

    public void setIndex(int index)
    {
        robotIndex = index;
    }

    public int getIndex()
    {
        return robotIndex;
    }

    private void OnMouseDown()
    {
        gameManager.setActiveRobot(robotIndex);
        Debug.Log(robotIndex);
    }

}
