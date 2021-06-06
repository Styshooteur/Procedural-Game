using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public Transform Player
    {
        set => player = value;
    }
    [SerializeField] float smoothing;
    [SerializeField] Vector3 offset;
    void Update() // Camera that follows the player
    {
        if (player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPosition;

        }

    }
}
