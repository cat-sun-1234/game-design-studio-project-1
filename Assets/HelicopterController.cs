using UnityEngine;

public class HelicopterController : MonoBehaviour
{

    public float moveSpeed = 5f;
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private Vector2 moveDirection;

    [SerializeField]
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            // Get horizontal and vertical input (from arrow keys or WASD)
            float moveHorizontal = Input.GetAxis("Horizontal"); //
            float moveVertical = Input.GetAxis("Vertical");     //

            // Calculate movement vector
            moveDirection = new Vector2(moveHorizontal, moveVertical);
    }

    void FixedUpdate()
    {
    if (rb2d != null)
    {
        rb2d.linearVelocity = moveDirection * moveSpeed;
    }
    }

    void onCollisionEnter (Collision collision)
    {
       // if (other.)
    }
}
