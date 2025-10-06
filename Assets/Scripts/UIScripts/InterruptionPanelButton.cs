using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterruptionPanelButton : MonoBehaviour
{
    public void OnClickYesButton()
    {
        Debug.Log("[Interruption.Button] ÉQÅ[ÉÄÇíÜífÇµÇ‹Ç∑");
    }

    public void OnClickNoButton()
    {
        Debug.Log("[Interruption.Button] Ç±ÇÃÇ‹Ç‹ë±ÇØÇ‹Ç∑");
        MenuUIManager.Instance.InterruptionPanel.SetActive(false);
    }
}
