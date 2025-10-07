using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;


public class PosePanelButton : MonoBehaviour
{
/*    [SerializeField, Tooltip("�Z�[�u�{�^��")] Button m_saveButton;
    [SerializeField, Tooltip("���[�h�{�^��")] Button m_loadButton;
    [SerializeField, Tooltip("���ʒ��߃{�^��")] Button m_volumeControlButton;
    [SerializeField, Tooltip("���f�{�^��")] Button m_interruptionButton;*/


    public void OnClickSaveButton()
    {
        Debug.Log("[Button] �Z�[�u�{�^����������܂���");
    }

    public void OnClickLoadButton()
    {
        Debug.Log("[Button] ���[�h�{�^����������܂���");
    }

    public void OnClickVolumeControlButton()
    {
        Debug.Log("[Button] ���ʒ��߃{�^����������܂���");
    }

    public void OnClickInterruptionButton()
    {
        Debug.Log("[Button] ���f�{�^����������܂���");
        MenuUIManager.Instance.InterruptionPanel.SetActive(true);
    }

    public void OnClickItemButton()
    {
        Debug.Log("[Button] �A�C�e���{�^����������܂���");
    }

    public void OnClickStatusButton()
    {
        Debug.Log("[Button] �X�e�[�^�X�{�^����������܂���");
    }
}
