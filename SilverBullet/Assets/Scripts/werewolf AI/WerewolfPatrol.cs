using UnityEngine;
using System.Collections;

public class WerewolfPatrol : WerewolfState {

    private int currentPatrolPoint = 0;

    public WerewolfPatrol(wwStateMachine sm, WerewolfAI wai) : base(sm, wai)
    {}

    public override void Start()
    {
        wai.GetNMA().SetDestination(wai.patrolPoints[currentPatrolPoint].position);
        wai.GetNMA().speed = 4;
        wai.GetNMA().stoppingDistance = 1;
    }

    public override void Update()
    {
        if(base.CheckScent())
        {
            
        }
        else if(base.CheckSight())
        {
            sm.ChangeState(new WerewolfSight(sm, wai));
        }
        
        if(Vector3.Distance(wai.transform.position, wai.patrolPoints[currentPatrolPoint].position) < 3)
        {
            if(currentPatrolPoint < wai.patrolPoints.Length-1)
            {
                currentPatrolPoint++;
            }
            else
            {
                currentPatrolPoint = 0;
            }
            wai.GetNMA().destination = wai.patrolPoints[currentPatrolPoint].position;
        }
    }
}
