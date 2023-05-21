using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : IState
{
    public IStateMachine StateMachine { get; private set; }
    
    private MenuWindow _menuWindow;
    public GameMenuState(MenuWindow menuWindow, IStateMachine sm)
    {
        _menuWindow = menuWindow;
        StateMachine = sm;
    }

    public void Enter()
    {
        _menuWindow.Show();
        _menuWindow.PlayButton.onClick.AddListener(()=>StateMachine.TrySwichState<GamePlayState>());
    }

    public void Exit()
    {
        _menuWindow.Hide();
        _menuWindow.PlayButton.onClick.RemoveAllListeners();
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        
    }
}
