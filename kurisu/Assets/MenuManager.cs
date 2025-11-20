using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject confirmNewGamePanel;
    public GameObject noSavePanel;
    public GameObject tutorialPanel;
    public string levelSelectionScene;

    public void NewGame()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            confirmNewGamePanel.SetActive(true);
        }
        else
        {
            namePanel.SetActive(true);
        }
    }

    public void ConfirmNewGame()
    {
        PlayerPrefs.DeleteKey("SavedGame");
        namePanel.SetActive(true);
        confirmNewGamePanel.SetActive(false);
    }

    public void SubmitName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(levelSelectionScene);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SceneManager.LoadScene(levelSelectionScene);
        }
        else
        {
            noSavePanel.SetActive(true);
        }
    }

    public void Tutorial()
    {
        StartCoroutine(ShowTutorial());
    }

    IEnumerator ShowTutorial()
    {
        tutorialPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        tutorialPanel.SetActive(false);
    }

    public void CloseAllPanels()
    {
        namePanel.SetActive(false);
        confirmNewGamePanel.SetActive(false);
        noSavePanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }
}
