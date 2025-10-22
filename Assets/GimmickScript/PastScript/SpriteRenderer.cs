using UnityEngine;

public class SpriteOrderOffset : MonoBehaviour
{
    public int orderOffset = 10; // ���L�������O�ɏo�����߂̃I�t�Z�b�g

    void Start()
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in renderers)
        {
            sr.sortingOrder += orderOffset;
        }
    }
}