using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_Scipt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
}
