using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private float elapsedTime = 0f;

    private float score = 0f;

    public float ScoreMultiplier = 10f;

    public float thrustForce = 1f;

    Rigidbody2D rb;

    public UIDocument uiDocument;

    private Label scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    // Update is called once per frame
    void Update()

    {
        elapsedTime += Time.deltaTime;

        score = Mathf.FloorToInt(elapsedTime * ScoreMultiplier);

        Debug.Log("Score: " + score);

        scoreText.text = "Score: " + score;

        if (Mouse.current.leftButton.isPressed)
        {

            //Caculate mouse direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
          
            Vector2 direction = (mousePos - transform.position).normalized;


            //MOVE PLAYER IN DIRECTION
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
