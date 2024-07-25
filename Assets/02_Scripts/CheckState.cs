using System;
using UnityEngine;
using Unity.Muse.Behavior;
using Action = Unity.Muse.Behavior.Action;

[Serializable]
[NodeDescription(name: "CheckState", story: "[Player] 와 [Monster] 간의 거리를 계산해서 [State] 를 변경 [TraceDist] [AttackDist]", category: "Action", id: "25a359432ad045351fd9dfbf6e37c517")]
public class CheckState : Action
{
    public BlackboardVariable<GameObject> Player;
    public BlackboardVariable<GameObject> Monster;
    public BlackboardVariable<State> State;
    public BlackboardVariable<float> TraceDist;
    public BlackboardVariable<float> AttackDist;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float distance = Vector3.Distance(Monster.Value.transform.position, Player.Value.transform.position);

        if (distance < TraceDist.Value) {
            State.Value = global::State.TRACE;
        }

        if (distance < AttackDist.Value) {
            State.Value = global::State.ATTACK;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

