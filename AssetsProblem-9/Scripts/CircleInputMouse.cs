﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInputMouse : MonoBehaviour
{
    public Transform point;
    public float speed;
    private Rigidbody2D rigidBody2D;
    private Vector3 cursorPos;
    private Vector3 direction;
    private bool spamCheck;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        point.position = cursorPos;
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (cursorPos - transform.position).normalized;

        PushBall(direction);
    }

    void PushBall(Vector3 dir)
    {
        if (Input.GetMouseButtonDown(0) && spamCheck == false)
        {
            rigidBody2D.velocity = new Vector2(dir.x * speed, dir.y * speed);
            spamCheck = true;
            StartCoroutine(SpamCheck());
        }
    }

    IEnumerator SpamCheck() 
    {
        yield return new WaitForSeconds(0.5f);
        spamCheck = false;
    }
}