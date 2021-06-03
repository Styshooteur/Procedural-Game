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
    
    void Start()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
        _currentHealth -= damage;
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
    }
}
