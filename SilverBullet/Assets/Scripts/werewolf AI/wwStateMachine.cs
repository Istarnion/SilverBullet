using System.Collections;
using System.Collections.Generic;

public class wwStateMachine {

    WerewolfState currentState;


    public wwStateMachine(WerewolfState ws)
    {
        ChangeState(ws);
    }

    public void Update()
    {
        if(currentState != null)
        {
            currentState.Update();
        }
    }

    public void ChangeState(WerewolfState ws)
    {
        if (ws != null)
        {
            this.currentState = ws;
            currentState.Start();
        }
    }
}
