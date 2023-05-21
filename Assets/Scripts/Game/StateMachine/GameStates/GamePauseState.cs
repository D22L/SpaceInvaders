using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : IState
{
    public IStateMachine StateMachine { get; private set; }

    private PauseWindow _pauseWindow;

    public GamePauseState(PauseWindow pauseWindow, IStateMachine stateMachine)
    {
        _pauseWindow = pauseWindow;
        StateMachine = stateMachine;
    }

    public void Enter()
    {
        _pauseWindow.Show();
        _pauseWindow.ExitButton.onClick.AddListener(()=>Application.Quit());
        _pauseWindow.ContinueButton.onClick.AddListener(StateMachine.TrySwichState<GamePlayState>);

        Time.timeScale = 0f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;

        _pauseWindow.Hide();
        _pauseWindow.ExitButton.onClick.RemoveAllListeners();
        _pauseWindow.ContinueButton.onClick.RemoveAllListeners();
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        
    }
}
