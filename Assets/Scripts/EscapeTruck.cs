using UnityEngine;

public class EscapeTruck : MonoBehaviour, IInteractable
{
    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] Timer timer;
    public void Interact()
    {
        waveSpawner.StartSpawning();
        timer.StartTimer();
    }
}
