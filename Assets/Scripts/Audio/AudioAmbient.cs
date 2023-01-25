using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAmbient : MonoBehaviour
{
    [SerializeField] private float _timeTransation;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;

    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float _timeDuration;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ChangeAudio();
    }

    public void ChangeAudio()
    {
        _audioSource.volume = _minVolume;

        _audioSource.Play();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while(_audioSource.volume != _maxVolume)
        {
            _timeDuration += _timeTransation * Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _timeDuration);

            yield return null;
        }
    }
}
