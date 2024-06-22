public abstract class BaseState
{
    public Enemy enemy;
    public StateMachine statemachine;
    public abstract void Enter();

    public abstract void Perform();

    public abstract void Exit();
}