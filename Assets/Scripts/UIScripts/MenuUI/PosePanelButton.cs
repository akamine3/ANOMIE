using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;


public class PosePanelButton : MonoBehaviour
{
/*    [SerializeField, Tooltip("セーブボタン")] Button m_saveButton;
    [SerializeField, Tooltip("ロードボタン")] Button m_loadButton;
    [SerializeField, Tooltip("音量調節ボタン")] Button m_volumeControlButton;
    [SerializeField, Tooltip("中断ボタン")] Button m_interruptionButton;*/


    public void OnClickSaveButton()
    {
        Debug.Log("[Button] セーブボタンが押されました");
    }

    public void OnClickLoadButton()
    {
        Debug.Log("[Button] ロードボタンが押されました");
    }

    public void OnClickVolumeControlButton()
    {
        Debug.Log("[Button] 音量調節ボタンが押されました");
    }

    public void OnClickInterruptionButton()
    {
        Debug.Log("[Button] 中断ボタンが押されました");
        MenuUIManager.Instance.InterruptionPanel.SetActive(true);
    }

    public void OnClickItemButton()
    {
        Debug.Log("[Button] アイテムボタンが押されました");
    }

    public void OnClickStatusButton()
    {
        Debug.Log("[Button] ステータスボタンが押されました");
    }
}
