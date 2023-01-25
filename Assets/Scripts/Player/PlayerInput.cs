using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private PlayerState _playerState;
    private bool _mouseButtonDown;
    private bool _spaceKeyDown;
    private bool _isWorking = true;
    
    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;
    public bool MouseButtonDown => _mouseButtonDown;
    public bool SpaceKeyDown => _spaceKeyDown;
    public bool IsWorking => _isWorking;

    private void Awake()
    {
        _playerState = GetComponent<PlayerState>();
    }
    private void Update()
    {
        if (!_mouseButtonDown && Time.timeScale != 0 && _isWorking == true)
        {
            _mouseButtonDown = Input.GetMouseButtonDown(0);
            _horizontalInput = 0;
            _verticalInput = 0;
        }

        if (!_spaceKeyDown && Time.timeScale != 0)
            _spaceKeyDown = Input.GetKeyDown(KeyCode.Space);

        if (_playerState.IsAttack == false)
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

    private void OnDisable()
    {
        ClearCache();
    }

    public void ClearCache()
    {
        _mouseButtonDown = false;
        _spaceKeyDown = false;
        _horizontalInput = 0;
        _verticalInput = 0;
    }

    public void DisableWorking()
    {
        _isWorking = false;
    }

    public void EnableWorking()
    {
        _isWorking = true;
    }
}