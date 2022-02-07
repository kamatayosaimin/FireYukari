using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerState _state;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    [SerializeField] private AtsumaruManager _atsumaruManager;
    private AtsumaruPad _atsumaruPad;
    [SerializeField] private PlayScene _main;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _state = PlayerState.Start;
        _atsumaruPad = _atsumaruManager.Pad;
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
                break;
            case PlayerState.DeadFall:
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
