using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCombat : MonoBehaviour
{
    private bool _batCombat = false;
    [SerializeField] private Transform _bat;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int batAttackDamage = 10;
    [SerializeField] private int batMaxHealth = 50;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Projectile web;
    private int _batCurrentHealth;
    
    private void Start()
    {
        _batCurrentHealth = batMaxHealth;
    }

    void FixedUpdate()
    {
        if (_batCombat == true)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(_bat.position, attackRange, playerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<PlayerCombat>().TakeDamage(batAttackDamage);
                Debug.Log("Player receive" + batAttackDamage);
            }
        } 
    }
    
    private void BatTakeDamage(int damage)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/EnemyHurt");
        StartCoroutine(FlashRed());
        _batCurrentHealth -= damage;
        Debug.Log("good damage " + web.damage);
        if (_batCurrentHealth <= 0)
        {
            Die();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("StartingCombat");
            _batCombat = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.GetComponent<BoxCollider2D>().IsTouching(other))
        {
            Debug.Log("Good Hitbox");
            if (other.gameObject.layer == LayerMask.NameToLayer("Web"))
            {
                BatTakeDamage(web.damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_bat == null)
            return;
        
        Gizmos.DrawWireSphere(_bat.position, attackRange);
    }
    
    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        sprite.color = Color.white;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
