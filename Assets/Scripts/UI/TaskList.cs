using TMPro;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    [SerializeField] private string[] _tasks;
    [SerializeField] private Character _character;

    private TMP_Text _text;
    private int _taskNumber = 0;

    private void OnEnable()
    {
        _character.HasTake += Render;
        _character.HasTake += ChangeTask;
    }

    private void OnDisable()
    {
        _character.HasTake -= Render;
        _character.HasTake -= ChangeTask;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        Render();
    }
    private void Render()
    {
        _text.text = _tasks[_taskNumber];
    }

    private void ChangeTask()
    {
        _taskNumber++;
        Render();
    }
}