using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance { get; private set; }


    [Header("Pose")]
    [SerializeField] private GameObject m_posePanel;
    [SerializeField] private GameObject m_interruptionPanel;



    public GameObject PosePanel => m_posePanel;
    public GameObject InterruptionPanel => m_interruptionPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
