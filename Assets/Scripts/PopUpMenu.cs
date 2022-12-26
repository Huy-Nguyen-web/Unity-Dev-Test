using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpMenu : MonoBehaviour
{
    public TextMeshProUGUI label;
    public void ShowPopUp(string text)
    {
        label.text = text;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
