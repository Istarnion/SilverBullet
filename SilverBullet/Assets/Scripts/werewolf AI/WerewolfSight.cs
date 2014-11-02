using UnityEngine;
using System.Collections;

public class WerewolfSight : WerewolfState {

    private Vector3 lastPlayerPos;

    public WerewolfSight(wwStateMachine sm, WerewolfAI wai) : base(sm, wai)
    { }

	public override void Start () {
        Debug.Log("You are seen!");
        wai.GetNMA().SetDestination(wai.GetPlayer().transform.position);
        lastPlayerPos = wai.GetPlayer().transform.position;
        wai.GetNMA().speed = 7;
	}
	
	public override void Update () {
	    if(Vector3.Distance(lastPlayerPos, wai.GetPlayer().transform.position) > 2)
        {
            wai.GetNMA().SetDestination(wai.GetPlayer().transform.position);
        }
	}
}
