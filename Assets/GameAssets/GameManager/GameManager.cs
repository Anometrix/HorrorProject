using System.Collections;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager Instance { get; private set; }

    public bool isPowerOn { get; private set;  } // Power state variable
    private int FPS = 60;
    public bool isDead { get; private set; }

    public bool greenKeyCardCollected { get; private set; }
    public bool redKeyCardCollected { get; private set; }
    public bool MasterKeyCardCollected { get; private set; }

    [Header("Task Objectives")]
    [SerializeField] private GameObject task1;
    [SerializeField] private GameObject task2;
    [SerializeField] private GameObject task3;
    [SerializeField] private GameObject genEnabled;
    [SerializeField] private GameObject genDisabled;
    [SerializeField] private GameObject deathScreen;
    [Header("Audio")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioSource deathSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioSource screamSource;
    [SerializeField] private AudioClip screamClip;
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

        musicSource.clip = musicClip;
        deathSource.clip = deathClip;
        screamSource.clip = screamClip;

        screamSource.ignoreListenerPause = true;
        deathSource.ignoreListenerPause = true;

        musicSource.Play();

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
    public void PlayerDeath()
    {
        if (isDead) return; // Prevent multiple death triggers
        isDead = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathScreen.SetActive(true);

        musicSource.Stop();
        screamSource.Play();
        deathSource.Play();

        Time.timeScale = 0f; // Pause the game when the player dies

        StartCoroutine(StopScreamSound()); // Start a coroutine to stop the scream sound after it finishes playing
    }
    public IEnumerator StopScreamSound()
    {
        yield return new WaitForSecondsRealtime(screamClip.length + 1f); // Wait for the scream sound to finish playing
        screamSource.Stop(); // Stop the scream sound
    }
}
