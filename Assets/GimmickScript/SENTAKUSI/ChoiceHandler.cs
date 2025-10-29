using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public static string selectedOption; // ‘I‘ğŒ‹‰Ê‚ğ•Û

    public void ChooseOption(string option)
    {
        selectedOption = option;
        Debug.Log("‘I‘ğˆ: " + selectedOption);
    }
}