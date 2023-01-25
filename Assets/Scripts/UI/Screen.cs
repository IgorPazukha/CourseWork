using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button ButtonRestart;
    [SerializeField] protected Button ButtonMainMenu;

    protected abstract void OnButtonClickRestart();
    protected abstract void OnButtonClickMainMenu();

    public abstract void Open();

    public abstract void Close();
}