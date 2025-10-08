using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIManager : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*---------- 以下ボタンクリック時処理 ----------*/
    public void OnClickItemIcon()
    {
        Debug.Log("[Button] アイテムが選択されました");
    }

    public void OnClickItemUseButton()
    {
        Debug.Log("[Button] アイテム使用ボタンがクリックされました");
    }

    public void OnClickOrdinaryItemsTab()
    {
        Debug.Log("[Button] 通常アイテムタブが選択されました");
    }

    public void OnClickConsumablesTab()
    {
        Debug.Log("[Button] 消耗品タブが選択されました");
    }

    public void OnClickPassiveItems()
    {
        Debug.Log("[Button] パッシブアイテムタブが選択されました");
    }




}
