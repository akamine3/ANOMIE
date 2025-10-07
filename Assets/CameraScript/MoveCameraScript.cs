using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    public Transform player;    // プレイヤー
    public Vector2 minPosition; // マップの左下の座標
    public Vector2 maxPosition; // マップの右上の座標

    void LateUpdate()
    {
        if (player != null)
        {
            // プレイヤーを追従する位置(プレイヤーのX,Y軸に合わせます)
            float targetX = player.position.x;
            float targetY = player.position.y;

            // マップの範囲内にClamp(固定)する(Zは固定)
            float clampedX = Mathf.Clamp(targetX, minPosition.x, maxPosition.x);
            float clampedY = Mathf.Clamp(targetY, minPosition.y, maxPosition.y);

            transform.position = new Vector3(clampedX, clampedY, -10f);
        }
    }
}