using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenPause : Screen
{
    [SerializeField] private Button _buttonResume;

    public event UnityAction RestartButtonClick;
    public event UnityAction MainMenuButtonClick;
    public event UnityAction ResumeButtonClick;

    private void OnEnable()
    {
        _buttonResume.onClick.AddListener(OnButtonClickResume);
        ButtonRestart.onClick.AddListener(OnButtonClickRestart);
        ButtonMainMenu.onClick.AddListener(OnButtonClickMainMenu);
    }

    private void OnDisable()
    {
        _buttonResume.onClick.RemoveListener(OnButtonClickResume);
        ButtonRestart.onClick.RemoveListener(OnButtonClickRestart);
        ButtonMainMenu.onClick.RemoveListener(OnButtonClickMainMenu);
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        ButtonRestart.interactable = false;
        ButtonMainMenu.interactable = false;
        _buttonResume.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        ButtonRestart.interactable = true;
        ButtonMainMenu.interactable = true;
        _buttonResume.interactable = true;
    }

    protected override void OnButtonClickMainMenu()
    {
        MainMenuButtonClick?.Invoke();
    }

    protected override void OnButtonClickRestart()
    {
        RestartButtonClick?.Invoke();
    }

    private  void OnButtonClickResume()
    {
        ResumeButtonClick?.Invoke();
    }
}