using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // プレイヤーのTransform
    public Vector3 offset = new Vector3(0, 0,-10); // カメラの位置調整

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}