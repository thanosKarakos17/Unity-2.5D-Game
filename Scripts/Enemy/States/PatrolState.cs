using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int index;
    // Start is called before the first frame update
    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            if(index < enemy.path.waypoints.Count - 1)
            {
                index++;
            }
            else
            { index = 0; }
            enemy.Agent.SetDestination(enemy.path.waypoints[index].position);
        }
    }
}
