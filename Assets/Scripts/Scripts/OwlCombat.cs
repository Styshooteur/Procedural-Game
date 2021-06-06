using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlCombat : MonoBehaviour
{
    private bool _batCombat = false;
    [SerializeField] private Transform owl;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int owlAttackDamage = 10;
    [SerializeField] private int owlMaxHealth = 200;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Projectile web;
    private int _owlCurrentHealth;
    
    // Update is called once per frame

    private void Start()
    {
        _owlCurrentHealth = owlMaxHealth;
    }

    void FixedUpdate()
    {
        if (_batCombat == true)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(owl.position, attackRange, playerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<PlayerCombat>().TakeDamage(owlAttackDamage);
                Debug.Log("Player receive" + owlAttackDamage);
            }
        } 
    }
    
    private void BatTakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
        _owlCurrentHealth -= damage;
        Debug.Log("good damage " + web.damage);
        if (_owlCurrentHealth <= 0)
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
        if (owl == null)
            return;
        
        Gizmos.DrawWireSphere(owl.position, attackRange);
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
