using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public static string selectedOption; // �I�����ʂ�ێ�

    public void ChooseOption(string option)
    {
        selectedOption = option;
        Debug.Log("�I����: " + selectedOption);
    }
}