using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
  [SerializeField] IState _currentState;

  public void ChangeState(IState State)
  {
    if (_currentState != null && State.GetType() == _currentState.GetType())
    {
      return;
    }
    if (_currentState != null)
    {
      _currentState.Exit();
    }
    _currentState = State;
    if (_currentState != null)
    {
      _currentState.Enter();

    }

  }
  void Update()
  {
    if (_currentState != null)
    {
      _currentState.Execute();
    }
  }
}
