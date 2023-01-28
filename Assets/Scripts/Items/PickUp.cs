using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PickUpType _type;
    [SerializeField] private int _value;

    public int Value => _value;
    public PickUpType Type => _type;

    public enum PickUpType
    {
        Heal, Coin
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            other.gameObject.GetComponent<Player>().PickUpItem(this);

            Destroy(gameObject);
        }
    }
}