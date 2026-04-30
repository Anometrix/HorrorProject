using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStuffs : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject pauseMenu;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isDead)
        {
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true); // Show the pause menu
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to normal
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false); // Hide the pause menu
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart the game
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
