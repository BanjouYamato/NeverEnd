using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    public static ObserverManager Instance {  get; private set; }
    Dictionary<string, List<Action>> actions = new();
    private void Awake()
    {
        Instance = this;
    }
    public void RegisterObserver(string name,Action action)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new List<Action>());
        }
        actions[name].Add(action);
    }

    public void RemoveFromObserver(string name, Action action)
    {
        if (!actions.ContainsKey(name)) return;
        actions[name].Remove(action);
    }

    public void TriggerAction(string name)
    {
        if(!actions.ContainsKey(name)) return;
        foreach (Action action in actions[name])
        {
            action?.Invoke();
        }
    }
}
