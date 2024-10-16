using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    Rigidbody2D _rigi;
    [SerializeField] PlayerState _playerState = PlayerState.Idle;
    [SerializeField] AttackState _attackState = AttackState.NoAttack;
    AnimationController _anim;
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _anim = this.gameObject.transform.GetChild(0).GetComponent<AnimationController>();

    }

    void Update()
    {
        UpdateStatePlayer();
        _anim.UpdateState(_playerState);
        UpdateAttack();
        _anim.UpdateAttackAnimation(_attackState);

    }
    void UpdateStatePlayer()
    {
        if (_rigi.velocity.x != 0 && _rigi.velocity.y == 0)
        {
            _playerState = PlayerState.Run;
        }
        else if (_rigi.velocity.y != 0)
        {
            _playerState = PlayerState.Jump;
        }
        else
        {
            _playerState = PlayerState.Idle;
        }
    }

    void UpdateAttack()
    {
        if (Input.GetKey(KeyCode.O))
        {
            _attackState = AttackState.Skill_1;
            return;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            _attackState = AttackState.Punch;
            return;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            _attackState = AttackState.Kick;
            return;
        }
        else
        {
            _attackState = AttackState.NoAttack;
            return;
        }
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Jump
    }

    public enum AttackState
    {
        NoAttack,
        Kick,
        Punch,
        Skill_1
    }
}
