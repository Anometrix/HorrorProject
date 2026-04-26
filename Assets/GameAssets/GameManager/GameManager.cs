using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager Instance { get; private set; }

    public bool isPowerOn { get; private set;  } // Power state variable
    private int FPS = 60;

    public bool greenKeyCardCollected { get; private set; }
    public bool redKeyCardCollected { get; private set; }
    public bool MasterKeyCardCollected { get; private set; }
    [Header("Task Objectives")]
    [SerializeField] private GameObject task1;
    [SerializeField] private GameObject task2;
    [SerializeField] private GameObject task3;
    [SerializeField] private GameObject genEnabled;
    [SerializeField] private GameObject genDisabled;
    #endregion
    #region Awake, Start, and Update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPowerOn = false; // Initialize power state to off at the start of the game
    }
    private void Update()
    {
        if (greenKeyCardCollected && redKeyCardCollected && !MasterKeyCardCollected)
        {
            task1.SetActive(false);
            task2.SetActive(true);
        }
        else if (MasterKeyCardCollected)
        {
            task2.SetActive(false);
            task3.SetActive(true);
        }

        if (isPowerOn)
        {
            genEnabled.SetActive(true);
            genDisabled.SetActive(false);
        }
         else
        {
            genEnabled.SetActive(false);
            genDisabled.SetActive(true);
        }
    }
    #endregion
    public bool PowerEnabler() 
    {
        isPowerOn = true;
        return isPowerOn;
    }
    public void CollectCard(string cardColor) // Method to collect key cards based on their color
    {
        switch (cardColor)
        {
            case "Green":
                greenKeyCardCollected = true;
                break;
            case "Red":
                redKeyCardCollected = true;
                break;
            case "Master":
                MasterKeyCardCollected = true;
                break;
        }
    }
    public bool CheckCardCollected(string cardColor) // Method to check if a specific key card has been collected
    {
        return cardColor switch
        {
            "Green" => greenKeyCardCollected,
            "Red" => redKeyCardCollected,
            "Master" => MasterKeyCardCollected,
            _ => false,
        };
    }
}
