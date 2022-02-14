using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour, HealthSystem
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ILivingEntity _character;
    [SerializeField] private HeadsUpDisplay _hud;
    private void Awake()
    {
        if(_hud != null)
        {
            _hud._health = (HealthSystem)this;
        }
        _inputReader = GetComponent<InputReader>();
        _character = GetComponent<ILivingEntity>();
    }
    public void AlterCurrentHealth(int deltaHealth)
    {
        _currentHealth += deltaHealth;
        EnsureHealth();
    }
    public void AlterMaxHealth(int deltaMaxHealth)
    {
        _maxHealth += deltaMaxHealth;
        EnsureHealth();
    }
    public void Death()
    {
        if (_inputReader != null)
        {
            _inputReader.NeutralizeInputs();
        }
        if (_character != null)
        {
            _character.Kill();
        }
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    public int GetMaxHealth()
    {
        return _maxHealth;
    }
    public void SetCurrentHealth(int health)
    {
        _currentHealth = health;
        EnsureHealth();
    }
    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        EnsureHealth();
    }
    private void EnsureHealth()
    {
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
    }
}
