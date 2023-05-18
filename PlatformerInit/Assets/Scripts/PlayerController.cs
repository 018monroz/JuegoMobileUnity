using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D body;
    bool jumpable;
    [SerializeField] float jumpforce = 20;
    [SerializeField] float speed = 1;
    public float horizontalInput = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.acceleration.x;
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (jumpable && body.velocity.y <= 0)
        {
            body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            jumpable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) jumpable = true;
        if (collision.gameObject.CompareTag("Platform")) jumpable = true;
    }

}
