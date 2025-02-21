using UnityEngine;

public class Finalpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeManager timeManager = FindFirstObjectByType<TimeManager>();
            timeManager.OnFinishReach();
        }
    }
}
