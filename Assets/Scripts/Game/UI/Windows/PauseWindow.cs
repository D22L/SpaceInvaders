using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : ABaseUIWindow
{
    [field: SerializeField] public Button ExitButton { get; private set; }
    [field: SerializeField] public Button ContinueButton { get; private set; }
}
