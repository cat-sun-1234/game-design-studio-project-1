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

    [SerializeField]
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

            // Get horizontal and vertical input (from arrow keys or WASD)
            float moveHorizontal = Input.GetAxis("Horizontal"); 
            float moveVertical = Input.GetAxis("Vertical");     

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

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            Debug.Log("Collided with an object tagged 'Soldier'!");
            if (gameManager.soldiersInHelicopter < 3)
            {
                gameManager.soldiersInHelicopter++;
                gameManager.soldiersOnField--;
                source.Play();
                GameObject.Destroy(other.gameObject);
            }

        }
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Collided with an object tagged 'Tree'!");
            gameManager.GameOver();
        }
        if (other.gameObject.CompareTag("Base"))
        {
            Debug.Log("Collided with an object tagged 'Base'!");
            gameManager.soldiersRescued += gameManager.soldiersInHelicopter;
            gameManager.soldiersInHelicopter = 0;
        }
    }
   // void onCollisionEnter2D (Collision collision)
   // {
   //     if (collision.gameObject.CompareTag("Soldier"))
   //     {
   //         Debug.Log("Collided with an object tagged 'Soldier'!");
   //     }
   //     if (collision.gameObject.CompareTag("Tree"))
   //     {
   //         Debug.Log("Collided with an object tagged 'Tree'!");
   //     }
   //     if (collision.gameObject.CompareTag("Base"))
    //    {
    //       Debug.Log("Collided with an object tagged 'Base'!");
   //     }
    // }
}
