using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
  public Animator _animator;
  void Start()
  {
    _animator = GetComponent<Animator>();
  }
  public void SetTrigger()
  {
    _animator.SetBool("Rest 2", true);
    _animator.SetBool("Rest", false);

  }
}