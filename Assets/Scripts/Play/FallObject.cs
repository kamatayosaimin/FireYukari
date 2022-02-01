using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallObject : MonoBehaviour
{
    [SerializeField] private InstantSound _hitSound;

    protected abstract void Hit(PlayerController playerController);

    //// Start is called before the first frame update
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if (!playerController)
            return;

        if (_hitSound)
            Instantiate(_hitSound, transform.position, Quaternion.identity);

        Hit(playerController);
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Ground ground = collision.GetComponent<Ground>();

        if (!ground)
            return;

        Destroy(gameObject);
    }
}
