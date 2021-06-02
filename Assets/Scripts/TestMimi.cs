using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TestMimi : MonoBehaviour
{
    //Player character script
    
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Rigidbody2D playerBody;
    private const float MoveSpeed = 5.0f;
    private Vector2 Movement;
    private Vector2 MousePos;

    void Start()
    {
        Cursor.visible = true;
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + Movement * MoveSpeed * Time.fixedDeltaTime);

        Vector2 LookDir = MousePos - playerBody.position;
        float Angle_ = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;

        playerBody.rotation = Angle_;
    }
}

