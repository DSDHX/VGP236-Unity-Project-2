using System.Collections;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 6f;
    public float ballForce = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            Vector3 rollDirection = transform.up;
            rb.AddForce(rollDirection * ballForce, ForceMode.Impulse);
        }
    }
}
