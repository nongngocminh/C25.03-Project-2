using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterData
{
    public NavMeshAgent agent;
    private Vector3 destination;

    //public bool IsDestination => Vector3.Distance(destination, Vector3.right * TF.position.x + Vector3.forward * TF.position.z) < 0.1f;

    //protected override void Start()
    //{
    //    base.Start();
    //    ChangeState(new PatrolState());
    //}

    public override void OnInit()
    {
        base.OnInit();
        //ChangeAnim(Constants.ANIM_IDLE);
    }

    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destination = position;
        destination.y = 0;
        agent.SetDestination(position);
    }

    //IState<Bot> currentState;

    private void Update()
    {
        //if (GameManager.Instance.IsState(GameState.Gameplay) && currentState != null)
        //{
        //    currentState.OnExecute(this);
        //    CanMove(TF.position);
        //}
    }

    //public void ChangeState(IState<Bot> state)
    //{
    //    if (currentState != null)
    //        currentState.OnExit(this);

    //    currentState = state;

    //    if (currentState != null)
    //        currentState.OnEnter(this);
    //}

    internal void MoveStop()
    {
        agent.enabled = false;
    }
}
