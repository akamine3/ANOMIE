using UnityEngine;

public class SpriteOrderOffset : MonoBehaviour
{
    public int orderOffset = 10; // 他キャラより前に出すためのオフセット

    void Start()
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in renderers)
        {
            sr.sortingOrder += orderOffset;
        }
    }
}