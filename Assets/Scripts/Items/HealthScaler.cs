using UnityEngine;

public class HealthScaler : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float _speed;
    [SerializeField] [Range(1f, 10f)] private float _scale;
    [SerializeField] [Range(1f, 50f)] private float _divider;

    private void FixedUpdate()
    {
        transform.localScale += (_scale * (new Vector3(Mathf.Sin(Time.time * _speed), Mathf.Sin(Time.time * _speed), Mathf.Sin(Time.time * _speed))))/ _divider;
    }
}