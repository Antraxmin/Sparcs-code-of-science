using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    private Rigidbody2D rb;
    private Vector2 moveInput; // 입력 방향

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        // 이동 입력 받기
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void MoveUp()
    {
        rb.MovePosition(rb.position + Vector2.up * moveSpeed * Time.fixedDeltaTime); // 위로 이동
    }

    public void MoveDown()
    {
        rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.fixedDeltaTime); // 아래로 이동
    }

    public void MoveLeft()
    {
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.fixedDeltaTime); // 왼쪽으로 이동
    }

    public void MoveRight()
    {
        rb.MovePosition(rb.position + Vector2.right * moveSpeed * Time.fixedDeltaTime); // 오른쪽으로 이동
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽과 충돌했을 때 이동을 멈추기
        if (collision.gameObject.CompareTag("Wall")) // "Wall" 태그가 붙은 오브젝트와 충돌
        {
            // 이동 방향을 0으로 설정하여 멈춤
            moveInput = Vector2.zero; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 벽과 충돌이 끝나면 이동이 가능하도록 함
        if (collision.gameObject.CompareTag("Wall")) 
        {
            // 벽에서 나가면 입력을 다시 받아서 이동할 수 있도록 함
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}

// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; // 플레이어 이동 속도
//     private Rigidbody2D rb;

//     private Vector2 movementDirection; // 이동 방향

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
//     }

//     private void Update()
//     {
//         // Rigidbody2D의 위치를 부드럽게 업데이트
//         rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
//     }

//     public void MoveUp(bool isPressed)
//     {
//         movementDirection.y = isPressed ? 1 : 0; // 위로 이동
//     }

//     public void MoveDown(bool isPressed)
//     {
//         movementDirection.y = isPressed ? -1 : 0; // 아래로 이동
//     }

//     public void MoveLeft(bool isPressed)
//     {
//         movementDirection.x = isPressed ? -1 : 0; // 왼쪽으로 이동
//     }

//     public void MoveRight(bool isPressed)
//     {
//         movementDirection.x = isPressed ? 1 : 0; // 오른쪽으로 이동
//     }
// }
