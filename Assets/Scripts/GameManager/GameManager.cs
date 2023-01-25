using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ScreenPause _screenPause;
    [SerializeField] private ScreenGameOver _screenGameOver;
    [SerializeField] private SpawnerGroup _spawnerGroup;

    private Player _player;

    private void OnEnable()
    {
        _pauseButton.PauseActivate += OnPauseButtonClick;
        _screenPause.ResumeButtonClick += OnResumeButtonClick;
        _screenPause.RestartButtonClick += OnRestartButtonClick;
        _screenPause.MainMenuButtonClick += OnMainMenuButton;
        _screenGameOver.RestartButtonClick += OnRestartButtonClick;
        _screenGameOver.MainMenuButtonClick += OnMainMenuButton;
        _player.Dying += EndGame;
        _spawnerGroup.HasDieAllEnemy += DieAllEnemy;
    }

    private void OnDisable()
    {
        _pauseButton.PauseActivate -= OnPauseButtonClick;
        _screenPause.ResumeButtonClick -= OnResumeButtonClick;
        _screenPause.RestartButtonClick -= OnRestartButtonClick;
        _screenPause.MainMenuButtonClick -= OnMainMenuButton;
        _screenGameOver.RestartButtonClick -= OnRestartButtonClick;
        _screenGameOver.MainMenuButtonClick -= OnMainMenuButton;
        _player.Dying -= EndGame;
        _spawnerGroup.HasDieAllEnemy -= DieAllEnemy;
    }
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        Time.timeScale = 1;
    }


    private void EndGame()
    {
        Time.timeScale = 0;
        _screenGameOver.Open();
    }

    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _screenPause.Open();
    }

    private void OnRestartButtonClick()
    {
        _screenPause.Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void OnResumeButtonClick()
    {
        _screenPause.Close();
        Time.timeScale = 1;
    }

    private void OnMainMenuButton()
    {
        MainMenu.Load();
    }

    private void DieAllEnemy()
    {
        EndGame();
    }
}