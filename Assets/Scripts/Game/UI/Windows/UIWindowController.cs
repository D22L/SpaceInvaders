using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowController : MonoBehaviour
{
    [SerializeField] public List<ABaseUIWindow> _windows = new List<ABaseUIWindow>();

    public T GetWindow<T>() where T: ABaseUIWindow
    {
        var window = _windows.Find(x => x is T);
        if (window == null) return null;
        return (T)window;
    }
}
