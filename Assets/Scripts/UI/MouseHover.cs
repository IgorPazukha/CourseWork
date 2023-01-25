using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsHovered { get; private set; }
    [SerializeField] private PlayerInput PlayerInput;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovered = true;
        PlayerInput.DisableWorking();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovered = false;
        PlayerInput.EnableWorking();
    }
}