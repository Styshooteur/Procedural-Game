using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private BatCombat batCombat;
    //[SerializeField] private BoxCollider2D batBox;
    public int damage = 10;
    private const float TimeToLive = 3f;

        public int Damage
    {
        get => damage;
        set => damage = value;
    }

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bat"))
        {

        }
    }*/
}