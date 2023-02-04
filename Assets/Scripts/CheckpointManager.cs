using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] _checkpoints;

    private void Start() { _checkpoints = GetComponentsInChildren<Checkpoint>(); }

    public Checkpoint GetLastActivatedCheckpoint()
    {
        Checkpoint lastCheckpoint = _checkpoints.Last(cp => cp.Activated);
        return lastCheckpoint;
    }
}