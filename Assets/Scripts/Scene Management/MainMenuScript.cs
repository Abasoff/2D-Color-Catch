using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public void ChoseMode()
    {
        SceneManager.LoadScene("ChooseModeScene");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGameManeger()
    {
        Application.Quit();
    }

    public void NormalMode()
    {
        SceneManager.LoadScene("GameSceneNormalMode");
    }
    public void SpeedUpMode()
    {
        SceneManager.LoadScene("GameSceneSpeedUpMode"); 
    }
}
