using UnityEngine;

public class PendulumHit : MonoBehaviour
{
    public float pushForce = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 hitDirection = collision.transform.position - transform.position;
            hitDirection = Vector3.Cross(hitDirection, transform.up).normalized;

            collision.rigidbody.AddForce(hitDirection * pushForce, ForceMode.Impulse);
        }
    }
}
