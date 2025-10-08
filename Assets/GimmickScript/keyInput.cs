using UnityEngine;

public class keyInput : MonoBehaviour
{
    public float speed =100f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 100f; // ← ここで強制的に設定


        

    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D)) movement.x += 1;
        if (Input.GetKey(KeyCode.A)) movement.x -= 1;
        if (Input.GetKey(KeyCode.W)) movement.y += 1;
        if (Input.GetKey(KeyCode.S)) movement.y -= 1;

        // アニメーション制御
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("isWalking", isWalking);

        // モデルの反転（右向きなら scale.x = 1、左向きなら -1）
        if (movement.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = movement.x > 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        // Rigidbody2Dで移動（揺れ防止）
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
