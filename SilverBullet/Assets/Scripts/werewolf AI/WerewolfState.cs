using UnityEngine;
using System.Collections;

public abstract class WerewolfState {

    protected wwStateMachine sm;
    protected WerewolfAI wai;

    public WerewolfState(wwStateMachine sm, WerewolfAI wai)
    {
        this.sm = sm;
        this.wai = wai;
    }

    public abstract void Start();

    public abstract void Update();

    protected bool CheckScent()
    {
        return false;
    }

    protected bool CheckSight()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(wai.transform.position, (wai.GetPlayer().transform.position - wai.transform.position));
        Vector3 playerPos = wai.GetPlayer().transform.position;
        playerPos.y += 1; // To compensate for the players position being at ground level. We want to aim for the center of the player instead.
        Vector3 dir = (playerPos - wai.transform.position);
        if (Physics.Raycast(wai.transform.position, dir, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
