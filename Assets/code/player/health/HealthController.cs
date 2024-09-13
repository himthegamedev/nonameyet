using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public bool Iframes { get; set;}

    public UnityEvent OnDied;
    public UnityEvent Ondamaged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }
        else
        {
            Ondamaged.Invoke();
        }

        if (Iframes)
        {
            return;
        }
        
        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
    }

    public void Addhealth(float amountToAdd)
    {
        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }


}

