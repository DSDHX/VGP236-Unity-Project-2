using UnityEngine;

public class PendulumTrap : MonoBehaviour
{
    public float swingAngle = 60f;
    public float swingSpeed = 5f;

    private Quaternion startRotation;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * swingSpeed;
        float angle = Mathf.Sin(timer) * swingAngle;
        transform.rotation = startRotation * Quaternion.Euler(angle, 0, 0);
    }
}
