using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float minX = -25f; // 左端の制限
    public float maxX = 75f;  // 右端の制限（背景の最後）

    private Rigidbody2D rb;
    private float moveInput;
    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 子オブジェクトの SpriteRenderer をすべて取得
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveInput < 0 ? -1 : 1);
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;

    }
}
