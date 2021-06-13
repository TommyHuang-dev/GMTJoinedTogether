﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotMovement : MonoBehaviour
{
    public float speed;

    GameManagerScript gameManager;
    Rigidbody2D robotRigidbody;
    BoxCollider2D boxCollider;
    RobotView robotView;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        boxCollider = GetComponent<BoxCollider2D>();
        robotRigidbody = GetComponent<Rigidbody2D>();
        robotView = GetComponent<RobotView>();
    }

    public void moveRobot(Vector2 movement)
    {
        robotRigidbody.MovePosition(robotRigidbody.position + movement * speed * Time.fixedDeltaTime);
    }




}
