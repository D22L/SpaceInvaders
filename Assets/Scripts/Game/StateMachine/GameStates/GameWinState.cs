public class GameWinState : IState
{
    public IStateMachine StateMachine { get; private set; }

    private WinWindow _winWindow;

    public GameWinState(WinWindow winWindow, IStateMachine stateMachine)
    {
        _winWindow = winWindow;
        StateMachine = stateMachine;
    }
    public void Enter()
    {
        _winWindow.Show();
        _winWindow.ContinueButton.onClick.AddListener(StateMachine.TrySwichState<GamePlayState>);
    }

    public void Exit()
    {
        _winWindow.Hide();
        _winWindow.ContinueButton.onClick.RemoveAllListeners();
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {

    }
}
