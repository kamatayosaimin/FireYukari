using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _initHp = 10;
    private int _hp;
    [SerializeField] private float _speed, _deadJump;
    private Animator _animator;
    private AudioSource _deadSound;
    private CapsuleCollider2D _collider;
    private PlayerState _state;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    [SerializeField] private AtsumaruManager _atsumaruManager;
    private AtsumaruPad _atsumaruPad;
    [SerializeField] private PlayScene _main;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _deadSound = GetComponent<AudioSource>();
        _collider = GetComponent<CapsuleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _hp = _initHp;
        _state = PlayerState.Start;
        _atsumaruPad = _atsumaruManager.Pad;

        _main.SetHp(_hp);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Start:
                break;
            case PlayerState.Playing:
                _atsumaruPad.Update();

                Move();

                break;
            case PlayerState.DeadJump:
                DeadJump();

                break;
            case PlayerState.DeadFall:
                DeadFall();

                break;
        }
    }

    public void GameStart()
    {
        _state = PlayerState.Playing;
    }

    public void AddScore(int add)
    {
        _main.AddScore(add);
    }

    public void Damage()
    {
        _hp--;

        _main.SetHp(_hp);

        if (_hp > 0)
            return;

        _state = PlayerState.DeadJump;

        _animator.enabled = false;

        _deadSound.Play();

        _collider.enabled = false;

        _rigidbody.drag = 0f;
        _rigidbody.velocity = Vector2.up * _deadJump;

        _main.PlayerDead();
    }

    void Move()
    {
        float horizontal = GetHorizontal();

        if (_renderer.flipX)
        {
            if (horizontal < 0f)
                _renderer.flipX = false;
        }
        else if (horizontal > 0f)
            _renderer.flipX = true;

        _rigidbody.AddForce(GetForce(horizontal), ForceMode2D.Force);
    }

    void DeadJump()
    {
        if (_rigidbody.velocity.y > 0f)
            return;

        _state = PlayerState.DeadFall;

        _renderer.flipY = true;
    }

    void DeadFall()
    {
        if (_deadSound.isPlaying)
            return;

        _main.GameOver();

        Destroy(gameObject);
    }

    float GetHorizontal()
    {
        float horizontal = Input.GetAxisRaw("Move") + _atsumaruPad.GetHorizontal();

        if (horizontal < 0f)
            return -1f;

        if (horizontal > 0f)
            return 1f;

        return 0f;
    }

    Vector2 GetForce(float x)
    {
        x *= _speed * Time.deltaTime;

        return new Vector2(x, 0f);
    }
}
