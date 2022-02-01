using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = GetHorizontal();

        //Debug.Log("Horizontal : " + horizontal);

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
        float horizontal = Input.GetAxisRaw("Move");

        if (horizontal < 0f)
            return -1f;

        if (horizontal > 0f)
            return 1f;

        return 0f;
    }

    Vector2 GetForce(float x)
    {
        x *= _speed;

        return new Vector2(x, 0f);
    }
}
