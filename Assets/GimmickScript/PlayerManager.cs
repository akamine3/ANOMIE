using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;


public class PlayerManager : MonoBehaviour
{
    public Tilemap WalkTileMap; // InspectorでTilemapを指定
    public Vector3 _startPos;
    public int _columnNum;
    public List<PlayerObj> _playerList = new List<PlayerObj>();
    public PlayerObj _nowObj;
    public Transform _playerObjCircle;
    public Transform _goalObjCircle;

    public static PlayerManager Instance;

    public Tilemap tilemap;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (_playerList != null && _playerList.Count > 0)
        {
            _nowObj = _playerList[2]; // 最初のプレイヤーを選択状態にする
            _playerObjCircle.transform.position = _nowObj.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                // プレイヤーをクリックした場合
                if (hit.collider.CompareTag("Player"))
                {
                    // 他のプレイヤーを選択できないようにする
                    PlayerObj clickedObj = hit.collider.GetComponent<PlayerObj>();
                    if (clickedObj == _nowObj)
                    {
                        // すでに選択されているプレイヤーならOK（何もしない or 再選択）
                    }
                    else
                    {
                        // 他のプレイヤーは無視
                        return;
                    }
                }
                else
                {
                    // 移動先をクリックした場合
                    if (_nowObj != null)
                    {
                        Vector3Int cellPos = WalkTileMap.WorldToCell(hit.point);
                        TileBase tile = WalkTileMap.GetTile(cellPos);

                        if (tile is WalkableTile walkableTile)
                        {
                            if (walkableTile.isWalkable)
                            {
                                Vector3 goalWorldPos = WalkTileMap.GetCellCenterWorld(cellPos);
                                _goalObjCircle.transform.position = goalWorldPos;
                                _nowObj.SetMovePos(goalWorldPos);

                                // シーン遷移タイルかどうかを判定
                                if (walkableTile.isSceneGate)
                                {
                                    SceneManager.LoadScene("Sample 1");
                                    Debug.Log("Scene Changed via Tile!");
                                }

                            }
                            else
                            {
                                Debug.Log("通行不可タイルです！");
                            }
                        }
                        else
                        {
                            Debug.Log("TileがWalkableTileじゃないか、存在しません");
                        }
                    }
                  
                }
            }

            if (_nowObj != null)
            {
                _playerObjCircle.transform.position = _nowObj.transform.position;
            }
        }
    }
}
