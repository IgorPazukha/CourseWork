using UnityEngine;

public class WindillRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime, Space.World);
    }
}