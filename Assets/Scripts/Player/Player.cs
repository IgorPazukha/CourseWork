using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Weapon _currentWeapon;

    private float _minHealht = 0f;
    private float _maxHealth = 100f;
    private int _coin = 0;

    public float Health => _health;
    public float MinHealth => _minHealht;
    public float MaxHealth => _maxHealth;
    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction Dying;
    public Action HasChangeHealth;
    public Action<int> HasChangeCoin;
    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health -= damage, _minHealht, _maxHealth);
        HasChangeHealth?.Invoke();

        if (_health <= 0)
        {
            Dying?.Invoke();
        }
    }

    public void PickUpItem(PickUp item)
    {
        switch (item.Type)
        {
            case PickUp.PickUpType.Heal:
                AddHealth(item.Value);
                break;
            case PickUp.PickUpType.Coin:
                AddCoin(item.Value);
                break;
        }
    }

    private void AddHealth(float health)
    {
        _health = Mathf.Clamp(_health += health, _minHealht, _maxHealth);
        HasChangeHealth?.Invoke();
    }

    private void AddCoin(int coin)
    {
        _coin += coin;
        HasChangeCoin?.Invoke(_coin);
    }
}