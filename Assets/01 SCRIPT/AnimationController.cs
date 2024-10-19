using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = State.PlayerState;
using AttackAnimation = State.AttackState;

public class AnimationController : MonoBehaviour
{
  public Animator _animator;
  void Start()
  {
    _animator = GetComponent<Animator>();
  }
  public void UpdateState(PlayerState _playerState)
  {
    for (int i = 0; i <= (int)PlayerState.Jump; i++)
    {
      string StateName = ((PlayerState)i).ToString();
      if (_playerState == (PlayerState)i)
      {
        _animator.SetBool(StateName, true);
      }
      else
      {
        _animator.SetBool(StateName, false);
      }
    }
  }
  public void UpdateAttackAnimation(AttackAnimation _attackState)
  {
    if ((int)_attackState == 1)
    {
      _animator.SetFloat("Attack", 0.2f);

    }
    else if ((int)_attackState == 2)
    {
      _animator.SetFloat("Attack", 0.4f);

    }
    else if ((int)_attackState == 3)
    {
      _animator.SetFloat("Attack", 0.6f);

    }
    else if ((int)_attackState == 4)
    {
      _animator.SetFloat("Attack", 0.8f);

    }
    else if ((int)_attackState == 5)
    {
      _animator.SetFloat("Attack", 1f);

    }
    else
    {
      _animator.SetFloat("Attack", (int)_attackState);

    }
  }

}