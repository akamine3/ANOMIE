using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterruptionPanelButton : MonoBehaviour
{
    public void OnClickYesButton()
    {
        Debug.Log("[Interruption.Button] �Q�[���𒆒f���܂�");
    }

    public void OnClickNoButton()
    {
        Debug.Log("[Interruption.Button] ���̂܂ܑ����܂�");
        MenuUIManager.Instance.InterruptionPanel.SetActive(false);
    }
}
