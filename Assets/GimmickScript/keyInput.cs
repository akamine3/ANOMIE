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
        speed = 100f; // �� �����ŋ����I�ɐݒ�


        

    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D)) movement.x += 1;
        if (Input.GetKey(KeyCode.A)) movement.x -= 1;
        if (Input.GetKey(KeyCode.W)) movement.y += 1;
        if (Input.GetKey(KeyCode.S)) movement.y -= 1;

        // �A�j���[�V��������
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("isWalking", isWalking);

        // ���f���̔��]�i�E�����Ȃ� scale.x = 1�A�������Ȃ� -1�j
        if (movement.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = movement.x > 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        // Rigidbody2D�ňړ��i�h��h�~�j
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
