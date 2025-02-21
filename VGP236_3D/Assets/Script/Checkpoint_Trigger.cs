using UnityEngine;

public class Checkpoint_Trigger : MonoBehaviour
{
    [SerializeField] private bool isFirstCheckpoint = false;

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
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.SetCheckpoint(transform.position);
                GetComponent<Collider>().enabled = false;
            }
            if (isFirstCheckpoint)
            {
                FindFirstObjectByType<TimeManager>().OnFirstCheckPoint();
            }
        }
    }
}
