using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class ItemUIManager : MonoBehaviour
{
    [Header("アイテム詳細表示パネル")]
    [SerializeField] private GameObject m_itemDetailsPanel;
    [SerializeField] private Image m_itemIcon;
    [SerializeField] private TextMeshProUGUI m_itemNameText;
    [SerializeField] private TextMeshProUGUI m_itemPossessionCount;
    [SerializeField] private TextMeshProUGUI m_itemExplanation;
    [SerializeField, Tooltip("アイテム未選択時テキスト")] private TextMeshProUGUI m_unselectedText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItemDetailsPanel(string itemId)
    {
        Debug.Log("[UI] アイテム詳細パネルを表示");
    }

}
