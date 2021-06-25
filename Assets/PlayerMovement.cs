using UnityEngine;
using InControl;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] float speed;
    [SerializeField] private SpriteRenderer sprite;
    private Vector2 _direction;
    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    private Vector2 _targetPos;
    private Animator _animator;

    public enum State
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    private State _stateDir;

    void Start()
    {
        camera = UnityEngine.Camera.main.GetComponent<Camera>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        camera.transform.position = transform.position + new Vector3(0, 0, -10);
        TakeInput();
        Move();
        SelfRotation();
    }
    
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    private void SelfRotation()
    {
        var dir = InputManager.ActiveDevice.RightStick.Value;
        if (dir.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(-Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90.0f, 0, 0));
        }
    }
    
    private void Move() //Moves the player
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        if (_direction.x != 0 || _direction.y != 0)                          // PUT DEADZONE HERE
        {
            _animator.SetTrigger("Walk");
            _animator.ResetTrigger("Idle");
        }
        else
        {
            _animator.SetTrigger("Idle");
            _animator.ResetTrigger("Walk");
        }
    }

    private void TakeInput() // Takes input to move the player
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.S) || InputManager.ActiveDevice.LeftStick.Down)
        {
            _direction += Vector2.up;
          _stateDir = State.UP;
        }
        if (Input.GetKey(KeyCode.W)|| InputManager.ActiveDevice.LeftStick.Up)
        {
            _direction += Vector2.down; 
            _stateDir = State.DOWN;
        }
        if (Input.GetKey(KeyCode.D)|| InputManager.ActiveDevice.LeftStick.Right)
        {
            _direction += Vector2.left; 
            _stateDir = State.LEFT;
        }
        if (Input.GetKey(KeyCode.A)|| InputManager.ActiveDevice.LeftStick.Left)
        {
            _direction += Vector2.right; 
            _stateDir = State.RIGHT;
        }
    }

}
