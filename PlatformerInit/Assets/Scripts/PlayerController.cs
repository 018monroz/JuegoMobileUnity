using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D body;
    bool jumpable;
    bool isTrampoline;
    [SerializeField] float jumpforce = 20;
    [SerializeField] float speed = 1;
    [SerializeField] Camera cam;
    public float horizontalInput = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpable = false;
        isTrampoline = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.acceleration.x;
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (jumpable && body.velocity.y <= 0)
        {
            if (isTrampoline)
            {
                body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                isTrampoline = false;
            }
            body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            jumpable = false;
        }

        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        bool isOnScreen = screenPos.y > 0 && screenPos.y < 1 && screenPos.x < 1 && screenPos.x > 0;
        if (!isOnScreen)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) jumpable = true;
        if (collision.gameObject.CompareTag("Platform")) jumpable = true;
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpable = true;
            isTrampoline = true;
        }
        
        if (collision.gameObject.CompareTag("Obstacle") && body.velocity.y <= 0) Die();
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
