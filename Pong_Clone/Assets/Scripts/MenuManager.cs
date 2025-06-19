using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;

    public void TogglePauseMenu()
    {
        bool isPaused = !pauseMenu.activeSelf;
        pauseMenu.SetActive(!pauseMenu);
        Time.timeScale = isPaused ? 0 : 1; // Pause or resume the game
    }
}
