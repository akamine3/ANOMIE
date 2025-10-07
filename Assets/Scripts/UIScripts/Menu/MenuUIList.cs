using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "UIScriptable/Create MenuUIList")]
public class MenuUIList : ScriptableObject
{
    public List<MenuButton> MenuButtonList = new List<MenuButton>();

    [System.Serializable]
    public class MenuButton
    {
        [SerializeField] private string m_buttonId;
        [SerializeField] Button m_menuButtonPrefab;

        public string ButtonId => m_buttonId;
        public Button MenuButtonPrefab => m_menuButtonPrefab;
    }


}
