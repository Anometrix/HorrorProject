using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuffs : MonoBehaviour
{
    #region Variables
    [Header("Apps (Menu Options)")]
    [SerializeField] private GameObject levelSelectApp;
    [SerializeField] private GameObject settingsApp;
    [SerializeField] private GameObject quitApp;
    [SerializeField] private GameObject creditApp;
    [Header("Credit Menu Options")]
    [SerializeField] private GameObject creditDevs;
    [SerializeField] private GameObject creditOther;
    [Header("Other")]
    [SerializeField] private AudioSource buttonClickSource;
    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private AudioSource menuMusicSource;
    [SerializeField] private AudioClip menuMusicClip;
    #endregion

    void Start()
    {
        buttonClickSource.clip = buttonClickClip;
        menuMusicSource.clip = menuMusicClip;
    }

    #region Open/Close Apps
    public void OpenCloseLevelSelect()
    {
        buttonClickSource.Play();
        levelSelectApp.SetActive(!levelSelectApp.activeSelf);
    }
    public void OpenCloseSettings()
    {
        buttonClickSource.Play();
        settingsApp.SetActive(!settingsApp.activeSelf);
    }
    public void OpenCloseQuit()
    {
        buttonClickSource.Play();
        quitApp.SetActive(!quitApp.activeSelf);
    }
    public void OpenCloseCredits()
    {
        buttonClickSource.Play();
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
        buttonClickSource.Play();
        creditDevs.SetActive(true);
        creditOther.SetActive(false);
    }
    public void SwitchCreditsPanelToOther()
    {
        buttonClickSource.Play();
        creditDevs.SetActive(false);
        creditOther.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
