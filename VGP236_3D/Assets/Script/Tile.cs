using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isReal;
    public bool isRevealed;
    private Material defaultMat;
    private Vector3 originPos;

    public int x;
    public int z;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultMat = GetComponent<MeshRenderer>().material;
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isRevealed)
            {
                Reveal();
            }
        }
    }

    public void Reveal()
    {
        isRevealed = true;
        if (isReal)
        {
            GetComponent<Renderer>().material.color = Color.green;
            GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        GetComponent<Collider>().enabled = false;
        float fallSpeed = 2f;

        while (transform.position.y > 4.52f)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject, 1f);
    }

    public void SetCoordinats(int xCoord, int zCoord)
    {
        x = xCoord;
        z = zCoord;
    }
}
