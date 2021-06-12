using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotView : MonoBehaviour
{
    public bool isInView(Transform other)
    {
        Vector2 direction = other.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, LayerMask.GetMask("Obstacles"));
        if (hit.collider == null) { return true; }
        return false;
    }
}
