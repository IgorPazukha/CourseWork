using UnityEngine;
using UnityEngine.Events;

public class ScreenGameOver : Screen
{
    public event UnityAction RestartButtonClick;
    public event UnityAction MainMenuButtonClick;

    private void OnEnable()
    {
        ButtonRestart.onClick.AddListener(OnButtonClickRestart);
        ButtonMainMenu.onClick.AddListener(OnButtonClickMainMenu);
    }

    private void OnDisable()
    {
        ButtonRestart.onClick.RemoveListener(OnButtonClickRestart);
        ButtonMainMenu.onClick.RemoveListener(OnButtonClickMainMenu);
    }
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        ButtonRestart.interactable = false;
        ButtonMainMenu.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        ButtonRestart.interactable = true;
        ButtonMainMenu.interactable = true;
    }

    protected override void OnButtonClickMainMenu()
    {
        MainMenuButtonClick?.Invoke();
    }

    protected override void OnButtonClickRestart()
    {
        RestartButtonClick?.Invoke();
    }
}