﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.score++;
            GameManager.itemCount--;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            GameManager.score--;
            GameManager.itemCount--;
            Destroy(gameObject);
        }
    }
}