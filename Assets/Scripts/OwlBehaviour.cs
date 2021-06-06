using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class OwlBehaviour : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField] private float dashSpeed;
    private float _dashTime;
    [SerializeField] private float startDashTime;
    private bool _playerSpotted = false;
    private Transform entityTransform;
    [SerializeField] private Transform player;

    public Transform Player
    {
        get => player;
        set => player = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        entityTransform = transform;
        _dashTime = startDashTime;
    }
    
    void FixedUpdate()
    {
        
        if (_playerSpotted)
        {
            var playerPosition = player.position;
            var deltaPlayerPos = playerPosition - entityTransform.position;
            _body.velocity = dashSpeed * deltaPlayerPos.normalized;
            _dashTime -= Time.fixedDeltaTime;

            if (_dashTime <= 0)
            {
                _dashTime = startDashTime;
                _body.velocity = Vector2.zero;
                _playerSpotted = false;
            }
        }

        /*else
        {
            body.velocity = entitySpeed * deltaPos.normalized;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("PlayerSpotted");
            _playerSpotted = true;
        }
    }
    
}
