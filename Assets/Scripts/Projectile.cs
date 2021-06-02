using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private const float TimeToLive = 3f;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {

        }
    }
}