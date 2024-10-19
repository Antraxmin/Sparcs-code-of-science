using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool canMoveUp = false;  // 사다리 안에 있을 때만 위로 이동 가능

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement = Vector2.zero;

        // 사다리 영역에서만 위로 이동
        if (isMovingUp && canMoveUp)
        {
            movement.y = 1;
        }
        else if (isMovingDown)
        {
            movement.y = -1;
        }

        if (isMovingLeft)
        {
            movement.x = -1;
            spriteRenderer.flipX = true; 
        }
        else if (isMovingRight)
        {
            movement.x = 1;
            spriteRenderer.flipX = false; 
        }
    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // 사다리 영역에 들어왔을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            canMoveUp = true;
            Debug.Log("Entered ladder Area");
        }
    }

    // 사다리 영역에서 나갔을 때
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            canMoveUp = false;
            Debug.Log("Exited ladder Area");
        }
    }

    public void OnMoveUpDown()
    {
        isMovingUp = true;
    }

    public void OnMoveUpUp()
    {
        isMovingUp = false;
    }

    public void OnMoveDownDown()
    {
        isMovingDown = true;
    }

    public void OnMoveDownUp()
    {
        isMovingDown = false;
    }

    public void OnMoveLeftDown()
    {
        isMovingLeft = true;
    }

    public void OnMoveLeftUp()
    {
        isMovingLeft = false;
    }

    public void OnMoveRightDown()
    {
        isMovingRight = true;
    }

    public void OnMoveRightUp()
    {
        isMovingRight = false;
    }
}
