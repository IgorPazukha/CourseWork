using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Color _maxHealthColor;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeDuration;

    private Color _minHealthColor = Color.red;
    private Coroutine _coroutine;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health;
    }

    private void OnEnable()
    {
        _player.HasChangeHealth += ChangeSlider;
    }

    private void OnDisable()
    {
        _player.HasChangeHealth -= ChangeSlider;
    }

    public void ChangeSlider()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while (_slider.value != _player.Health)
        {
            float colorChange = _player.Health / _player.MaxHealth;

            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, _timeDuration * Time.deltaTime);
            _healthBar.color = Color.Lerp(_minHealthColor, _maxHealthColor, colorChange);

            yield return null;
        }
    }
}