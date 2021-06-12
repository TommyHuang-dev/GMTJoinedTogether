using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //constants
    const int ROBOT_LAYER = 6;

    public RobotMovement[] robots;
    int activeRobotIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < robots.Length; ++i)
        {
            robots[i].setIndex(i);
        }

        Physics2D.IgnoreLayerCollision(ROBOT_LAYER, ROBOT_LAYER);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        robots[activeRobotIndex].moveRobot(movement);
    }

    public void setActiveRobot(int i)
    {
        activeRobotIndex = i;
    }
}
