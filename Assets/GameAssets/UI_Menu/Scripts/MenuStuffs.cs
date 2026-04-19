using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuffs : MonoBehaviour
{
    [Header("Apps (Menu Options)")]
    [SerializeField] private GameObject levelSelectApp;
    [SerializeField] private GameObject settingsApp;
    [SerializeField] private GameObject quitApp;
    [SerializeField] private GameObject creditApp;
    [Header("Credit Menu Options")]
    [SerializeField] private GameObject creditDevs;
    [SerializeField] private GameObject creditOther;
    [Header("Other")]
    [SerializeField] private GameObject otherApp;

    #region Open/Close Apps
    public void OpenCloseLevelSelect()
    {
        levelSelectApp.SetActive(!levelSelectApp.activeSelf);
    }
    public void OpenCloseSettings()
    {
        settingsApp.SetActive(!settingsApp.activeSelf);
    }
    public void OpenCloseQuit()
    {
        quitApp.SetActive(!quitApp.activeSelf);
    }
    public void OpenCloseCredits()
    {
        creditApp.SetActive(!creditApp.activeSelf);
    }
    #endregion

    public void StartLevel1()
    {
        SceneManager.LoadScene("Leszek");

        levelSelectApp.SetActive(false);
        settingsApp.SetActive(false);
        quitApp.SetActive(false);
    }
    public void SwitchCreditsPanelToDevs()
    {
        creditDevs.SetActive(true);
        creditOther.SetActive(false);
    }
    public void SwitchCreditsPanelToOther()
    {
        creditDevs.SetActive(false);
        creditOther.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
