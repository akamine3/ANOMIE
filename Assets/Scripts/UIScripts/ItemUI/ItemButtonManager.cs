using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonManager : MonoBehaviour
{
    public void OnClickItemIcon()
    {
        Debug.Log("[Button] アイテムが選択されました");
    }

    public void OnClickUseButton()
    {
        Debug.Log("[Button] アイテム使用ボタンがクリックされました");
        // アイテムの所持数を減らす処理
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
