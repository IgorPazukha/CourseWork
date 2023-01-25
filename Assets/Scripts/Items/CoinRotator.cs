using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Rotate(0f, _speed * Time.deltaTime, 0f, Space.World);
    }
}