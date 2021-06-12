using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotView : MonoBehaviour
{
    //Transform transform;
    const int ROBOT_LAYER = 6;
    const int OBSTACLE_LAYER = 7;

    void Start()
    {
        //transform = GetComponent<Transform>();    
    }
    public bool isInView(Transform other)
    {
        Vector2 direction = other.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, LayerMask.GetMask("Obstacles"));
        //Debug.Log(LayerMask.GetMask("Obstacles"));
        //Debug.Log(LayerMask.GetMask("Robots"));
        if (hit.collider == null)
        {
            Debug.Log("Robot in line of sight");
            return true;
        }
        return false;
    }
}
