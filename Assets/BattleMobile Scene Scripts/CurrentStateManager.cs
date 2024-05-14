using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    battle,
    normal,
}

public class CurrentStateManager : MonoBehaviour
{
    public static CurrentStateManager instance;
    public GameObject battlemobile;
    public Animator animator;
    public State state;
    private bool isNormalMode;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = State.battle;
        isNormalMode = false;
        animator.SetBool("BattleMode", true);
        battlemobile.AddComponent<InputToMoveBattleMobile>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isNormalMode)
            {
                state = State.normal;
                isNormalMode = true;
            }
            else
            {
                state = State.battle;
                isNormalMode = false;
            }
        }
        CurrentState();
    }


    void CurrentState()
    {
        if (state == State.normal)
        {
            animator.SetBool("NormalMode", true);
        }
        else if (state == State.battle)
        {
            animator.SetBool("NormalMode", false);
        }
    }
}
