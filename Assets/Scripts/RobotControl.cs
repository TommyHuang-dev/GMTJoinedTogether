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

    public void setIndex(int index) { robotIndex = index; }
    public int getIndex() { return robotIndex; }
    public bool isInView(Transform otherTransform) { return robotView.isInView(otherTransform); }
    public void moveRobot(Vector2 movement) {
        if (!isSource && robotMovement) { robotMovement.moveRobot(movement); }
    }

    // Set active robot if clicked on
    void OnMouseDown() { gameManager.setActiveRobot(robotIndex); }
}
