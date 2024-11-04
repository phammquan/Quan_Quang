using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class StateManager : MonoBehaviourPunCallbacks
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
      if (photonView.IsMine)
      {
        _currentState.Enter();

      }

    }

  }
  void Update()
  {
    if (photonView.IsMine)
    {
      if (_currentState != null)
      {
        _currentState.Execute();
      }
    }

  }
}
