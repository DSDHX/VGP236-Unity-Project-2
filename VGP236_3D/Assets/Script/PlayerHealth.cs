using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float deathHealth = -10f;
    private Vector3 respawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deathHealth)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
       transform.position = respawnPoint;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }
}
