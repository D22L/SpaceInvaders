using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyCounterUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private EnemyCounter _enemyCounter;
    [Inject]
    private void Construct(EnemyCounter enemyCounter) 
    {
        _enemyCounter = enemyCounter;
    }

    private void OnEnable()
    {
        _scoreText.text = _enemyCounter.Value.ToString();
        _enemyCounter.OnChangeValue += _enemyCounter_OnChangeValue;
    }

    private void _enemyCounter_OnChangeValue()
    {
        _scoreText.text = _enemyCounter.Value.ToString();
    }

    private void OnDisable()
    {
        _enemyCounter.OnChangeValue -= _enemyCounter_OnChangeValue;
    }
}
