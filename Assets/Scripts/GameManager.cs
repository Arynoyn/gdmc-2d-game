using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private int _lives;
    private int _coins;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            RestartGame();
        }
    }

    internal void KillPlayer()
    {
        _lives--;
        
        if (OnLivesChanged != null)
        {
            OnLivesChanged(_lives);
        }

        if (_lives <= 0)
        {
            RestartGame();
        }
        else
        {
            SpawnPlayerAtLastCheckpoint();
        }
    }

    internal void AddCoin()
    {
        _coins++;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(_coins);
        }
    }

    private void RestartGame()
    {
        _lives = 3;
        if (OnLivesChanged != null)
        {
            OnLivesChanged(_lives);
        }
        
        _coins = 0;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(_coins);
        }
        
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    private void SpawnPlayerAtLastCheckpoint()
    {
        CheckpointManager checkpointManager = FindObjectOfType<CheckpointManager>();
        Checkpoint lastActivatedCheckpoint = checkpointManager.GetLastActivatedCheckpoint();
        
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = lastActivatedCheckpoint.transform.position;
    }
}
