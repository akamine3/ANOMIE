using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonManager : MonoBehaviour
{
    public void OnClickItemIcon()
    {
        Debug.Log("[Button] �A�C�e�����I������܂���");
    }

    public void OnClickUseButton()
    {
        Debug.Log("[Button] �A�C�e���g�p�{�^�����N���b�N����܂���");
        // �A�C�e���̏����������炷����
    }

    public void OnClickOrdinaryItemsTab()
    {
        Debug.Log("[Button] �ʏ�A�C�e���^�u���I������܂���");
    }

    public void OnClickConsumablesTab()
    {
        Debug.Log("[Button] ���Օi�^�u���I������܂���");
    }

    public void OnClickPassiveItems()
    {
        Debug.Log("[Button] �p�b�V�u�A�C�e���^�u���I������܂���");
    }
}
