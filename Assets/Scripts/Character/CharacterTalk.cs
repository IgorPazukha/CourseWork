using UnityEngine;
using UnityEngine.Events;

public class CharacterTalk : MonoBehaviour
{
    private bool _isMission = true;

    public event UnityAction<bool> HasTriggerZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player) && _isMission)
        {
            HasTriggerZone?.Invoke(true);
            _isMission = false;
        }
    }
}
