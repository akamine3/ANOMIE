using System.ComponentModel;
using UnityEngine;
using static ItemData;

[CreateAssetMenu(menuName = "MyGame/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int m_itemId;
    [SerializeField] private string m_itemName;
    [SerializeField] private ItemType m_type;
    [SerializeField] private UseType m_useType;
    [SerializeField] private Sprite m_icon;
    [TextArea, SerializeField] private string m_description;

    public enum ItemType { important, recovery, buff }  // important(重要), recovery(回復), buff(バフ)
    public enum UseType { None, Passive, Active }   // None(付与効果なし), Passive(所持しているだけで発動), Active(使用することで発動)

    public int ItemId => m_itemId;
    public string ItemName => m_itemName;
    public Sprite Icon => m_icon;
    public UseType UseTiming => m_useType;
    public ItemType Type => m_type;
    public string Description => m_description;
}