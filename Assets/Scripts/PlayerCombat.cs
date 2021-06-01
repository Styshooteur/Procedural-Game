using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private SpriteRenderer sprite;
    private int _currentHealth;
    // Start is called before the first frame update
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
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
