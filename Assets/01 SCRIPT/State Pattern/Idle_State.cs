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
    Debug.Log("Enter Idle");
  }

  public void Execute()
  {

  }

  public void Exit()
  {
    Debug.Log("Exit Idle");
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

  public void Execute()
  {




  }

  public void Exit()
  {
    _AnimController._animator.SetBool("Run", false);
    _AnimController._animator.SetBool("Rest", false);
  }

}

public class Run_State : IState
{
  AnimationController _AnimController;
  public Run_State(AnimationController AnimController)
  {
    this._AnimController = AnimController;

  }
  public void Enter()
  {
    _AnimController._animator.SetBool("Run", true);

  }

  public void Execute()
  {


  }

  public void Exit()
  {
    _AnimController._animator.SetBool("Run", false);
  }
}

public class Jump_State : IState
{
  AnimationController _AnimController;
  public Jump_State(AnimationController AnimController)
  {
    this._AnimController = AnimController;

  }
  public void Enter()
  {
    _AnimController._animator.SetBool("Jump", true);
  }

  public void Execute()
  {

  }

  public void Exit()
  {
    _AnimController._animator.SetBool("Jump", false);

  }
}
public class Punch : IState
{
  AnimationController _AnimController;
  public Punch(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {
    _AnimController._animator.SetTrigger("Punch");
  }

  public void Execute()
  {

  }

  public void Exit()
  {
    Debug.Log("Exit Punch");
  }
}

public class Kick : IState
{
  AnimationController _AnimController;
  public Kick(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {
    _AnimController._animator.SetTrigger("Kick");
  }

  public void Execute()
  {

  }

  public void Exit()
  {
    Debug.Log("Exit Kick");
  }
}
public class Skill : IState
{
  AnimationController _AnimController;
  public Skill(AnimationController AnimController)
  {
    this._AnimController = AnimController;
  }
  public void Enter()
  {
    Debug.Log("Enter Skill");
    _AnimController._animator.SetTrigger("Skill");
  }

  public void Execute()
  {
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
    Debug.Log("Exit Skill");
  }
}


