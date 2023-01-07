using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovementController playerMovementController = col.GetComponent<PlayerMovementController>();
        if (playerMovementController != null)
        {
            Passed = true;
        }
    }
}
