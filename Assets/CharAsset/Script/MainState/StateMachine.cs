using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    
    // Update is called once per frame

    public void SwitchState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState?.EnterState();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(Time.deltaTime);
        }
    }
}
