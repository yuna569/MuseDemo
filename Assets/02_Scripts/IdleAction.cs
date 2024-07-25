using System;
using UnityEngine;
using Unity.Muse.Behavior;
using Action = Unity.Muse.Behavior.Action;
using UnityEngine.AI;

[Serializable]
[NodeDescription(name: "IdleAction", story: "[Monster] 의 추적을 정지", category: "Action", id: "7fc4d2c3a3cf421c1e915d17a69d60a7")]
public class IdleAction : Action
{
    public BlackboardVariable<GameObject> Monster;

    protected override Status OnStart()
    {
        Monster.Value.GetComponent<NavMeshAgent>().isStopped = true;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

