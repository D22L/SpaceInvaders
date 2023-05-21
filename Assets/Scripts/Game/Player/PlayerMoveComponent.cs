using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IInputService _inputService;
    private WorldBorders _worldBordes;

    [Inject]
    public void Construct(IInputService inputService, GameWorldSettings gameWorldSettings) 
    {
        _inputService = inputService;
        _worldBordes = gameWorldSettings.WorldBorders;
    }

    private void Update()
    {        
        Move();
    }

    private void Move()
    {
        var step = new Vector3(_inputService.HorizontalInput, _inputService.VerticalInput);
        transform.position += step * Time.deltaTime * _speed;
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _worldBordes.MinX, _worldBordes.MaxX);
        pos.y = Mathf.Clamp(pos.y, _worldBordes.MinY, _worldBordes.MaxY);
        transform.position = pos;
    }
}
