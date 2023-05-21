using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateController : MonoBehaviour, IStateMachineHolder
{
    public StateMachine stateMachine { get; private set; }
    public GameMenuState gameMenu { get; private set; }
    public GamePlayState gamePlay { get; private set; }    
    public GameFailState gameFail { get; private set; }
    public GameWinState gameWin { get; private set; }

    public List<IState> States { get; private set; } = new List<IState>();

    private UIWindowController _winController;
    private PlayerController _playerController;
    private SwarmOfEnemies _swarmOfEnemies;
    private IInputService _inputService;

   [Inject]
    private void Constuct(UIWindowController uIWindow, PlayerController playerController, SwarmOfEnemies swarmOfEnemies, IInputService inputService)
    {
        _winController = uIWindow;
        _playerController = playerController;
        _swarmOfEnemies = swarmOfEnemies;
        _inputService = inputService;
    }

    private void Awake()
    {
        stateMachine = new StateMachine(this);

        gameMenu = new GameMenuState(_winController.GetWindow<MenuWindow>(), stateMachine); 
        gamePlay = new GamePlayState(_winController.GetWindow<GameWindow>(), stateMachine, _playerController, _swarmOfEnemies, _inputService);        
        gameFail = new GameFailState(_winController.GetWindow<FailWindow>(), stateMachine);
        gameWin = new GameWinState(_winController.GetWindow<WinWindow>(), stateMachine);
        
        States.Add(gameMenu);
        States.Add(gamePlay);        
        States.Add(gameFail);
        States.Add(gameWin);

        stateMachine.TrySwichState<GameMenuState>();
    }

    private void Update()
    {
        stateMachine?.Update();
    }
}
