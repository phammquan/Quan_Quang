using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
  public Animator _animator;
  bool check = false;
  void Start()
  {
    _animator = GetComponent<Animator>();
    Tran();

  }
  void Tran()
  {
    if (!check)
    {
      _animator.SetTrigger("Tran");
      check = true;
    }
  }
  public void SetTrigger()
  {
    _animator.SetBool("Rest 2", true);
    _animator.SetBool("Rest", false);

  }
}