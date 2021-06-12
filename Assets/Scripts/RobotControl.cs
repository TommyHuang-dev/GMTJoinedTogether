using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public RobotMovement robotMovement;
    public RobotView robotView;
    public GameManagerScript gameManager;

    // If robot is source, leave robotMovement as null
    public bool isSource;

    int robotIndex;
    bool isActive = false;

    public void setIndex(int index) { robotIndex = index; }
    public int getIndex() { return robotIndex; }
    public void activate() { isActive = true; }
    public void deactivate() { isActive = false; }
    public bool isInView(Transform otherTransform) { return robotView.isInView(otherTransform); }
    public void moveRobot(Vector2 movement) {
        if (isActive && !isSource && robotMovement) { robotMovement.moveRobot(movement); }
    }

    // Set active robot if clicked on
    void OnMouseDown() { gameManager.setActiveRobot(robotIndex); }
}
