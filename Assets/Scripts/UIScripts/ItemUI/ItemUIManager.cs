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


    /*---------- �ȉ��{�^���N���b�N������ ----------*/
    public void OnClickItemIcon()
    {
        Debug.Log("[Button] �A�C�e�����I������܂���");
    }

    public void OnClickItemUseButton()
    {
        Debug.Log("[Button] �A�C�e���g�p�{�^�����N���b�N����܂���");
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
