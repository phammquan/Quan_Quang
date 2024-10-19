using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
[RequireComponent(typeof(StateManager))]

public class PlayerController : MonoBehaviourPunCallbacks
{
  public Rigidbody2D _rigi;
  [SerializeField] float speed;
  [SerializeField] float jumpForce;
  [SerializeField] bool _isGroud;
  [SerializeField] float hp = 100;
  [SerializeField] float stamina = 100;
  AnimationController _anim;
  float speedcheck;

  [SerializeField] StateManager _stateManager;
  void Start()
  {
    _rigi = GetComponent<Rigidbody2D>();
    _anim = this.transform.GetChild(0).GetComponent<AnimationController>();
    _stateManager = GetComponent<StateManager>();
    speedcheck = speed;
  }

  void Update()
  {
    move();
    Attack();
    Rest_Stamina();
  }
  public void move()
  {
    if (photonView.IsMine)
    {
      _rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, _rigi.velocity.y);
      if (_rigi.velocity.x != 0 || _rigi.velocity.y != 0)
      {
        if (_rigi.velocity.x != 0)
        {
          _stateManager.ChangeState(new Run_State(_anim));
        }
        else
        {
          _stateManager.ChangeState(new Jump_State(_anim));
        }

      }
      else
      {
        _stateManager.ChangeState(new Idle_State(_anim));
      }


      if (_rigi.velocity.x > 0)
      {
        this.transform.localScale = new Vector3(1, 1, 1);
      }
      if (_rigi.velocity.x < 0)
      {
        this.transform.localScale = new Vector3(-1, 1, 1);
      }
      if (_isGroud)
      {
        if (Input.GetKeyDown(KeyCode.W))
        {
          _rigi.velocity = new Vector2(_rigi.velocity.x, jumpForce);
          speed /= 2;
          _rigi.gravityScale = 3f;
          _isGroud = false;
        }
      }

    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Platform"))
    {
      _isGroud = true;
      if (speed < speedcheck)
      {
        speed = speedcheck;
      }
    }
    else
    {
      _isGroud = false;
    }
  }

  void Attack()
  {

    if (Input.GetKeyDown(KeyCode.J))
    {
      _stateManager.ChangeState(new Punch(_anim));
    }
    if (Input.GetKeyDown(KeyCode.K))
    {
      _stateManager.ChangeState(new Kick(_anim));
    }
    if (stamina >= 30 && Input.GetKeyDown(KeyCode.U) ||
    Input.GetKeyDown(KeyCode.I) ||
    Input.GetKeyDown(KeyCode.O))
    {
      stamina -= 30;
      _stateManager.ChangeState(new Skill(_anim));
    }

  }
  bool check = false;
  void Rest_Stamina()
  {

    if (Input.GetKey(KeyCode.L))
    {
      if (!check)
      {
        _anim._animator.SetBool("Rest", true);
        check = true;
      }
      if (stamina < 100)
      {
        stamina += 0.1f;
      }
    }
    if (Input.GetKeyUp(KeyCode.L))
    {
      _anim._animator.SetBool("Rest", false);

      _anim._animator.SetBool("Rest 2", false);
      check = false;
    }
  }

}
