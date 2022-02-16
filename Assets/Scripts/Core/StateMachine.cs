using System.Collections;
using System.Collections.Generic;

public abstract class StateMachine
{
  private IState currentState;

  public void ChangeState(IState newState)
  {
    if (currentState != null)
      currentState.Exit();

    currentState = newState;
    currentState.Enter();
  }

  public void Update()
  {
    if (currentState != null) currentState.Execute();
  }
}
