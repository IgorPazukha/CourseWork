using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private float _cornerOpen;
    [SerializeField] private OpenTrigger _openTrigger;

    private bool _isMission = true;

    private int _counter = 0;

    private void OnEnable()
    {
        _openTrigger.HasTrigger += Open;
    }

    private void OnDisable()
    {
        _openTrigger.HasTrigger -= Open;
    }
    private void Open()
    {
        if(_isMission == true)
            StartCoroutine(ChangeValue());
    }
    private IEnumerator ChangeValue()
    {
        bool isWork = true;

        while(isWork)
        {
            transform.Rotate(0f, -1f, 0f, Space.World);
            _counter++;

            if(_counter >= _cornerOpen)
            {
                isWork = false;
                _isMission = false;
            }
                

            yield return null;
        }
    }
}