using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class OwlBehaviour : MonoBehaviour
{

    public enum State
    {
        Wait,
        Load,
        Dash,
        Regen,
        Reset,
    }

    public State currentState;
    
    
    private Rigidbody2D _body;
    [SerializeField] private float dashSpeed;
    [SerializeField] private SpriteRenderer sprite;
    private float _dashTime;
    [SerializeField] private float speed;
    [SerializeField] private float startDashTime;
    private bool _playerSpotted = false;
    private float _dashLoadTime;
    private float _dashLoadPeriod = 2f;
    private float _dashCooldownTime;
    private float _dashCooldownPeriod = 1f;
    private Transform entityTransform;
    private Transform player;
    private Vector3 initialPos;
    public Transform Player
    {
        get => player;
        set => player = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Wait;
        _body = GetComponent<Rigidbody2D>();
        //initialPos = entityTransform.position;
        entityTransform = transform;
        _dashTime = startDashTime;
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Wait:
                Debug.Log("Wait...");
                if (_playerSpotted == true)
                {
                    ChangeState(State.Load);
                }
                break;
            
            case State.Load:
                Debug.Log("Load...");
                _dashLoadTime += Time.deltaTime;
                if (_dashLoadTime <= _dashLoadPeriod)
                {
                    sprite.color = Color.blue;
                }

                if (_dashLoadTime > _dashLoadPeriod)
                {
                    sprite.color = Color.white;
                    ChangeState(State.Dash);
                }
                break;
            case State.Dash:
                Debug.Log("Dash...");
                _dashTime -= Time.fixedDeltaTime;

                if (_dashTime > 0)
                {
                    var playerSpottedPos = player.position;
                    var deltaPlayerPos = playerSpottedPos - entityTransform.position;
                    _body.velocity = dashSpeed * deltaPlayerPos.normalized;
                }

                if (_dashTime <= 0)
                {
                    _dashTime = startDashTime;
                    _body.velocity = Vector2.zero;
                    _playerSpotted = false;
                    ChangeState(State.Regen);
                }
                break;
            case State.Regen:
                Debug.Log("Regen...");
                _dashCooldownTime += Time.deltaTime;
                if (_dashCooldownTime > _dashCooldownPeriod && _playerSpotted == true)
                {
                    ChangeState(State.Load);
                }

                if (_dashCooldownTime > _dashCooldownPeriod && _playerSpotted == false)
                {
                    ChangeState(State.Reset);
                }
                break;
            case State.Reset:
                Debug.Log("Reset...");
                var deltaSpawnPos = initialPos - entityTransform.position;
                _body.velocity = speed * deltaSpawnPos.normalized;

                if (entityTransform.position == initialPos)
                {
                    ChangeState(State.Wait);
                }
                break;
            
            default:
                break;
        }
        
        /*if (_playerSpotted)
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
        }*/
    }

    void ChangeState(State state)
    {
        switch (state)
        {
            case State.Wait:
                break;
            case State.Load:
                break;
            case State.Dash:
                break;
            case State.Regen:
                break;
            case State.Reset:
                break;
            default:
                break;
        }

        currentState = state;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("PlayerSpotted");
            _playerSpotted = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("PlayerSpotted");
            _playerSpotted = true;
        }
    }
}
