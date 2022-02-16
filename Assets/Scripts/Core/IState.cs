using System.Collections;
using System.Collections.Generic;

public interface IState
{
  public void Enter();
  public void Execute();
  public void Exit();
}
