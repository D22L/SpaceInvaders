using UnityEngine.SceneManagement;
public class GameFailState : IState
{
    public IStateMachine StateMachine { get; private set; }

    private FailWindow _failWindow;
    public GameFailState(FailWindow failWindow, IStateMachine stateMachine)
    {
        StateMachine = stateMachine;
        _failWindow = failWindow;
    }

    public void Enter()
    {
        _failWindow.Show();
        _failWindow.RestartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
    
    public void Exit()
    {
        _failWindow.Hide();
        _failWindow.RestartButton.onClick.RemoveAllListeners();
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        
    }
}
