using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterTalk _characterTalk;

    private bool _isMissing;

    public bool IsMissing => _isMissing;

    public event UnityAction HasTake;

    private void OnEnable()
    {
        _characterTalk.HasTriggerZone += TakeMission;
    }

    private void OnDisable()
    {
        _characterTalk.HasTriggerZone -= TakeMission;
    }
    private void TakeMission(bool status)
    {
        _isMissing = status;
        HasTake?.Invoke();
    }
}
