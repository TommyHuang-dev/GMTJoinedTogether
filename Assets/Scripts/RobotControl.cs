using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public RobotMovement robotMovement;
    public RobotView robotView;
    public GameManagerScript gameManager;
    public LineRenderer lineRenderer;

    // If robot is source, leave robotMovement as null
    public bool isSource;

    int robotIndex;
    bool isActive = false;

    void Start()
    {
        hideLine();    
    }

    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
    }

    public void setIndex(int index) { robotIndex = index; }
    public int getIndex() { return robotIndex; }
    public void activate() {
        isActive = true;
        showLine();
    }
    public void deactivate() {
        isActive = false;
        hideLine();
    }
    public bool isInView(Transform otherTransform) { return robotView.isInView(otherTransform); }
    public void moveRobot(Vector2 movement) {
        if (isActive && !isSource && robotMovement) { robotMovement.moveRobot(movement); }
    }
    public void showLine() {lineRenderer.enabled = true; }
    public void hideLine() { lineRenderer.enabled = false; }

    public void setLineEndPoint(Vector3 end) { lineRenderer.SetPosition(1, end); }

    // Set active robot if clicked on
    void OnMouseDown() { gameManager.setActiveRobot(robotIndex); }
}
