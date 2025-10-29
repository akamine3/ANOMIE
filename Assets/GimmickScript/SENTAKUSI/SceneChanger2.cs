using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ChoiceHandler.selectedOption == "Button1")
            {
                SceneManager.LoadScene("Next6");
            }
            else if (ChoiceHandler.selectedOption == "Button2")
            {
                SceneManager.LoadScene("NextX");
            }
            else if (ChoiceHandler.selectedOption == "Button3")
            {
                SceneManager.LoadScene("Next7");
            }
        }
    }
}