using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float minSize = 0.5f;
    float maxSize = 2.0f;
    Rigidbody2D rb;

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
