using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

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
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void BackButton()
    {
        MainMenuButton();
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
