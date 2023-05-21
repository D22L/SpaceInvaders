public interface IState
{
    IStateMachine StateMachine { get; }
    void Enter();
    void Exit();
    void Update();
    void FixedUpdate();
}
