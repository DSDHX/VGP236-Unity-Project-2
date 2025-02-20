using System.Collections;
using UnityEngine;

public class PistonTrap : MonoBehaviour
{
    public float extendSpeed = 5f;
    public float retractSpeed = 3f;
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;

    private Vector3 retractedPos;
    private Vector3 extendedPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        retractedPos = transform.position;
        extendedPos = retractedPos + Vector3.back * 9.5f;
        StartCoroutine(MovePosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            while (Vector3.Distance(transform.position, extendedPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, extendedPos, extendSpeed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);

            while (Vector3.Distance(transform.position, retractedPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, retractedPos, retractSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
            collision.rigidbody.AddForce(pushDirection * 15f, ForceMode.Impulse);
        }
    }
}
