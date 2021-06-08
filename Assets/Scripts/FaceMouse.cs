using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FaceMouse : MonoBehaviour
{
    [SerializeField] private PlayerMovement dir;
    private Vector2 _direction;

    private void Start()
    {
        _direction = dir.Direction;
    }

    void Update()
    {
        faceMouse();        
    }
 
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);
 
        Vector2 _direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
 
        transform.up = -  _direction.normalized;
    }
}