using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    [SerializeField] private float destroyHeight = -11f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
