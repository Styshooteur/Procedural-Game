using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCombat : MonoBehaviour
{
    private bool _batCombat = false;
    [SerializeField] private Transform bat;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int batAttackDamage = 20;
    
    // Update is called once per frame
    void Update()
    {
        if (_batCombat == true)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(bat.position, attackRange, playerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<PlayerCombat>().TakeDamage(batAttackDamage);
                Debug.Log("Player receive damage");
            }
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

    private void OnDrawGizmosSelected()
    {
        if (bat == null)
            return;
        
        Gizmos.DrawWireSphere(bat.position, attackRange);
    }
}
