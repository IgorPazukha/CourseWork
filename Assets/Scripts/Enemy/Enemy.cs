using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private Player _target;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private EnemyHealthTable _enemyHealthTable;

    private bool _isDie = false;

    public bool IsDie => _isDie;
    public Player Target => _target;
    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction<Enemy> Dying;
    public event UnityAction HasDye;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        ShowFloatingText();

        if (_health <= 0)
        {
            _isDie = true;
            Dying?.Invoke(this);
            HasDye?.Invoke();
            Destroy(gameObject);
        }
    }

    private void ShowFloatingText()
    {
        var floatText = Instantiate(_enemyHealthTable, transform.position, Quaternion.identity, transform);
        floatText.GetComponent<TextMesh>().text = _health.ToString();
    }
}