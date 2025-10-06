using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �v���C���[��Transform
    public Vector3 offset = new Vector3(0, 0,-10); // �J�����̈ʒu����

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}