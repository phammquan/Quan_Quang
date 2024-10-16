using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody2D _rigi;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool _isGroud;
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
    }
    void move()
    {
        if (photonView.IsMine)
        {
            _rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, _rigi.velocity.y);
            if (_rigi.velocity.x > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            if (_rigi.velocity.x < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (_isGroud && Input.GetKeyDown(KeyCode.W))
            {
                _rigi.velocity = new Vector2(_rigi.velocity.x, jumpForce);
                _rigi.gravityScale = 3f;
                _isGroud = false;
            }
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _isGroud = true;
        }
        else
        {
            _isGroud = false;
        }
    }


}
