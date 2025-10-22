using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPast: MonoBehaviour
{

    public Transform target;      // �v���C���[�ȂǒǏ]�Ώ�
    public float smoothSpeed = 0.125f;
    public Vector3 offset;        // �J�����̈ʒu�����i��F������Ɂj


    public float minX; // ���[�̐���
    public float maxX; // �E�[�̐���

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // X���W�𐧌�
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
