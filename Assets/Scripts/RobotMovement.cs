﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotMovement : MonoBehaviour
{
    public Rigidbody2D robotRigidbody;
    public GameManagerScript gameManager;
    public float speed;

    int robotIndex;
    BoxCollider2D boxCollider;
    public RobotView robotView;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //robotView = GetComponent<RobotView>();
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
    }

    public bool isInView(Transform otherTransform) { return robotView.isInView(otherTransform); }

}
