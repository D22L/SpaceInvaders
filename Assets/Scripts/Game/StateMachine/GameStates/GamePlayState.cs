using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IState
{
    public IStateMachine StateMachine { get; private set; }
    
    private GameWindow _gameWindow;
    private PlayerController _playerController;
    private SwarmOfEnemies _swarmOfEnemies;
    private IInputService _inputService;
    public GamePlayState (GameWindow gameWindow, IStateMachine stateMachine, PlayerController playerController, SwarmOfEnemies swarmOfEnemies, IInputService inputService)
    {
        StateMachine = stateMachine;
        _gameWindow = gameWindow;
        _playerController = playerController;
        _swarmOfEnemies = swarmOfEnemies;
        _inputService = inputService;
    }

    public void Enter()
    {
        _gameWindow.Show();
        _gameWindow.PauseButton.onClick.AddListener(() => StateMachine.TrySwichState<GamePauseState>());

        _playerController.OnDead += _playerController_OnDead;
        _swarmOfEnemies.OnEndEnemies += _swarmOfEnemies_OnEndEnemies;

        if (StateMachine.PreviousState is GameWinState) _swarmOfEnemies.SpawnEnemies();

        _swarmOfEnemies.Play();
        _inputService.Initialize();
    }

    private void _swarmOfEnemies_OnEndEnemies()
    {
        StateMachine.TrySwichState<GameWinState>();
    }

    private void _playerController_OnDead()
    {
        StateMachine.TrySwichState<GameFailState>();
    }

    public void Exit()
    {
        _gameWindow.Hide();
        _gameWindow.PauseButton.onClick.RemoveAllListeners();
        _playerController.OnDead -= _playerController_OnDead;
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        
    }
}
