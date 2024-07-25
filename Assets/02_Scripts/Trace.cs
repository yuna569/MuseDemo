using System;
using UnityEngine;
using Unity.Muse.Behavior;
using Action = Unity.Muse.Behavior.Action;

[Serializable]
[NodeDescription(name: "Trace", story: "[Monster] 가 [Player] 를 추적", category: "Action", id: "25fdc1cdd5a1e289a049bec4f9d49ef6")]
public class Trace : Action
{
    public BlackboardVariable<GameObject> Monster;
    public BlackboardVariable<GameObject> Player;

    private NavMeshAgent agent;

    protected override Status OnStart()
    {
        agent = Monster.Value,GetComponent<NavMeshAgent>();

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        agent.SetDestination(Player.Value.transform.position);
        agent.isStopped = false;

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

