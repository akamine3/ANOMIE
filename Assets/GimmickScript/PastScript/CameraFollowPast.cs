using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPast: MonoBehaviour
{

    public Transform target;      // プレイヤーなど追従対象
    public float smoothSpeed = 0.125f;
    public Vector3 offset;        // カメラの位置調整（例：少し上に）


    public float minX; // 左端の制限
    public float maxX; // 右端の制限

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // X座標を制限
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
