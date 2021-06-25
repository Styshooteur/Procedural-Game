using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private SpriteRenderer sprite;
    private int _currentHealth;
    private bool _invincible = false;
    private float _invicibilityTime;
    private float _invicibilityPeriod = 2f;

    private void FixedUpdate()
    {
        if (_invincible)
        {
            _invicibilityTime += Time.fixedDeltaTime;

            if (_invicibilityTime > _invicibilityPeriod)
            {
                _invincible = false;
                Debug.Log("Notinvicible");
            }
        }
        
    }

    void Start()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        if (!_invincible)
        {
            StartCoroutine(FlashRed());
            _currentHealth -= damage;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/Hurt");
            _invicibilityTime = 0;
        }

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        SceneManager.LoadScene(1);
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        sprite.color = Color.white;
        _invincible = true;
        Debug.Log("Invicible");
    }

    private void ImmuneDelay()
    {
        if (_invincible)
        {
            _invicibilityTime += Time.fixedDeltaTime;

            if (_invicibilityTime >= _invicibilityPeriod)
            {
                _invincible = false;
                Debug.Log("Notinvicible");
            }
        }

        _invicibilityTime = 0;
    }
}
