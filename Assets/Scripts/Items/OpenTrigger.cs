using UnityEngine;
using UnityEngine.Events;

public class OpenTrigger : MonoBehaviour
{
    [SerializeField] private Character _character;

    public event UnityAction HasTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && _character.IsMissing == true)
            HasTrigger?.Invoke();
    }
}