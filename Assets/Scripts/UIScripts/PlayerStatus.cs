using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus : MonoBehaviour
{
    [Header("キャラクターステータス")]
    [Header("基本情報")]
    [SerializeField] private string m_name;
    [SerializeField, TextArea] private string m_description;
    [Space(10)]
    [Header("状態異常")]
    [SerializeField] StatusAilment m_statusAilment;
    [Space(10)]
    [Header("パラメータ群")]
    [SerializeField, Range(1, 999)] private int m_hp;
    [SerializeField, Range(1, 999)] private int m_maxHp;
    [SerializeField, Range(1, 999)] private int m_atk;
    [SerializeField, Range(1, 999)] private int m_dfe;
    [SerializeField, Range(1, 999)] private int m_speed;
    [SerializeField, Range(1, 999)] private int m_maxSpeed;


    // テスト用変数（後で変更の可能性）
    Color m_statusColor;

    private enum StatusAilment { normal, burn, poison, sleep };

    // Start is called before the first frame update
    void Start()
    {
        m_statusColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchStatusAilment(m_statusAilment);
    }

    private void SwitchStatusAilment(StatusAilment type)
    {
        switch (type) 
        {
            case StatusAilment.normal:
                m_statusColor = Color.white;
                break;
            case StatusAilment.poison:
                m_statusColor = Color.red;
                break;
            case StatusAilment.sleep:
                m_statusColor = Color.blue;
                break;
            case StatusAilment.burn:
                m_statusColor = Color.cyan;
                break;
        }

        GetComponent<SpriteRenderer>().color = m_statusColor;
    }
}
