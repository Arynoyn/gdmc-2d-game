﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerMovementController playerMovementController = col.collider.GetComponent<PlayerMovementController>();
        if (playerMovementController != null)
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
}