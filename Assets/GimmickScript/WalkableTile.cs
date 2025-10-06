using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Walkable Tile",menuName = "Custom/WalkableTile")]
public class WalkableTile : Tile
{
    public bool isWalkable = true;
    public bool isSceneGate = false;
    //�V�[���ړ��p�̃t���O
    public  bool isSceneTransition = false;
    //�ړ���̃V�[����
    public string targetSceneName;
}