using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject MainMenu;

    void Start()
    {
        MainMenuButton();
    }

    public void SoloButton()
    {
        LoadGameScene(1);
    }

    public void DuoButton()
    {
        LoadGameScene(2);
    }

    public void LoadGameScene(int numberOfPlayers) {
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void BackButton()
    {
        MainMenuButton();
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
