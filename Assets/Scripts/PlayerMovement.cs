// using UnityEngine;
// using UnityEngine.EventSystems;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 2f;
//     private Rigidbody2D rb;
//     private SpriteRenderer spriteRenderer;
//     private Vector2 movement;

//     private bool isMovingUp = false;
//     private bool isMovingDown = false;
//     private bool isMovingLeft = false;
//     private bool isMovingRight = false;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }

//     void Update()
//     {
//         movement = Vector2.zero;

//         if (isMovingUp)
//         {
//             movement.y = 1;
//         }
//         else if (isMovingDown)
//         {
//             movement.y = -1;
//         }

//         if (isMovingLeft)
//         {
//             movement.x = -1;
//             spriteRenderer.flipX = true; 
//         }
//         else if (isMovingRight)
//         {
//             movement.x = 1;
//             spriteRenderer.flipX = false; 
//         }
//     }

//     void FixedUpdate()
//     {
//         rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
//     }

//     public void OnMoveUpDown()
//     {
//         isMovingUp = true;
//     }

//     public void OnMoveUpUp()
//     {
//         isMovingUp = false;
//     }

//     public void OnMoveDownDown()
//     {
//         isMovingDown = true;
//     }

//     public void OnMoveDownUp()
//     {
//         isMovingDown = false;
//     }

//     public void OnMoveLeftDown()
//     {
//         isMovingLeft = true;
//     }

//     public void OnMoveLeftUp()
//     {
//         isMovingLeft = false;
//     }

//     public void OnMoveRightDown()
//     {
//         isMovingRight = true;
//     }

//     public void OnMoveRightUp()
//     {
//         isMovingRight = false;
//     }
// }


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement = Vector2.zero;  // 매 프레임마다 초기화

        if (isMovingUp)
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
        // movement 값이 0이 아닐 때만 움직임 처리
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
