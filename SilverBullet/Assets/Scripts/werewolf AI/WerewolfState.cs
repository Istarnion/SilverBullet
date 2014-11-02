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
        Vector3 origin = wai.transform.position;
        origin.y += 1;
        Vector3 playerPos = Camera.main.transform.position;
        Vector3 dir = (playerPos - origin);
        origin += (dir / dir.magnitude)*2;
        Debug.DrawRay(origin, dir);
        if (Physics.Raycast(origin, dir, out hitInfo, Mathf.Infinity))
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
