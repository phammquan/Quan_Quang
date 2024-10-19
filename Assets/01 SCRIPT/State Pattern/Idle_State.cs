using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : IState
{
  AnimationController _AnimController;
  public Idle_State(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {
    //_AnimController._animator.SetBool("Run", false);

  }

  public void Execute()
  {

  }

  public void Exit()
  {
    Debug.Log("Exit Idle");
  }

}
public class Attack_State : IState
{
  AnimationController _AnimController;
  public Attack_State(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {

  }

  public void Execute()
  {
    if (Input.GetKeyDown(KeyCode.K))
    {
      _AnimController._animator.SetTrigger("Kick");
    }
    if (Input.GetKeyDown(KeyCode.J))
    {
      _AnimController._animator.SetTrigger("Punch");
    }
    if (Input.GetKeyDown(KeyCode.U))
    {
      _AnimController._animator.SetTrigger("Skill");
      _AnimController._animator.SetFloat("Attack", 0f);
    }
    if (Input.GetKeyDown(KeyCode.I))
    {
      _AnimController._animator.SetTrigger("Skill");
      _AnimController._animator.SetFloat("Attack", 0.5f);
    }
    if (Input.GetKeyDown(KeyCode.O))
    {
      _AnimController._animator.SetTrigger("Skill");
      _AnimController._animator.SetFloat("Attack", 1f);
    }
  }

  public void Exit()
  {
  }
}
public class Move_State : IState
{
  AnimationController _AnimController;
  public Move_State(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {

  }

  public void Execute()
  {
    if (Input.GetKeyDown(KeyCode.W))
    {
      _AnimController._animator.SetTrigger("Jump");
    }
    if (Input.GetAxisRaw("Horizontal") != 0)
    {
      _AnimController._animator.SetBool("Run", true);
    }
    if (Input.GetKey(KeyCode.L))
    {
      _AnimController._animator.SetBool("Rest", true);
    }



  }

  public void Exit()
  {
    _AnimController._animator.SetBool("Run", false);
    _AnimController._animator.SetBool("Rest", false);



  }
}