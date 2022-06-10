using System;
using UnityEngine;
using UnityEngine.Events;

public class  EventAggregator : MonoBehaviour
{
    private static UnityEvent action = new UnityEvent();

    public static void Invoke()
    {
        action.Invoke();
    }

    public static void AddListener(UnityAction _action)
    {
        action.AddListener(_action);
    }

    public static void RemoveListener(UnityAction _action)
    {
        action.RemoveListener(_action);
    }
}
