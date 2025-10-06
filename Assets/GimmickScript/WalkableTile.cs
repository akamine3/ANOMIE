using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Walkable Tile",menuName = "Custom/WalkableTile")]
public class WalkableTile : Tile
{
    public bool isWalkable = true;
    public bool isSceneGate = false;
    //シーン移動用のフラグ
    public  bool isSceneTransition = false;
    //移動先のシーン名
    public string targetSceneName;
}