using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private string gateItemId; // この選択肢が開けるゲートのID
    [SerializeField] private GateController gateController;
    [SerializeField] private Button button;

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnChoiceSelected);
        }
    }

    void OnChoiceSelected()
    {
       /* foreach (var gate in gateController.GetGates())
        {
            if (gate.requiredItemId == gateItemId)
            {
                gateController.OpenGate(gate);
                break;
            }
        }*/
    }
}