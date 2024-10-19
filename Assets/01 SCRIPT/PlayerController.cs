using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
[RequireComponent(typeof(StateManager))]

public class PlayerController : MonoBehaviourPunCallbacks
{
  Rigidbody2D _rigi;
  [SerializeField] float speed;
  [SerializeField] float jumpForce;
  [SerializeField] bool _isGroud;
  AnimationController _anim;


  [SerializeField] StateManager _stateManager;
  void Start()
  {
    _rigi = GetComponent<Rigidbody2D>();
    _anim = this.transform.GetChild(0).GetComponent<AnimationController>();
    _stateManager = GetComponent<StateManager>();
  }

  void Update()
  {
    move();
    Attack();
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
    if (_rigi.velocity.y > 0 || _rigi.velocity.x != 0 || Input.GetKey(KeyCode.L))
    {
      _stateManager.ChangeState(new Move_State(_anim));
    }
    else
    {
      _stateManager.ChangeState(new Idle_State(_anim));
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

  void Attack()
  {
    if (Input.GetKeyDown(KeyCode.J) ||
       Input.GetKeyDown(KeyCode.K) ||
       Input.GetKeyDown(KeyCode.U) ||
       Input.GetKeyDown(KeyCode.I) ||
       Input.GetKeyDown(KeyCode.O))
    {
      _stateManager.ChangeState(new Attack_State(_anim));
    }
  }


}
