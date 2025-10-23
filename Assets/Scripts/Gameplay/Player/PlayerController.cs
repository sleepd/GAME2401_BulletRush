using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerSettings _settings;
    private Dictionary<Type, IPlayerComponent> _components;
    public PlayerStats Stats { get; private set; }

    void Awake()
    {
        _components = new();
        Stats = new(_settings);
        AddComponent<PlayerInput>();
        AddComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var component in _components.Values)
        {
            component.Update();
        }
    }

    void OnEnable()
    {
        foreach (var component in _components.Values)
        {
            component.OnEnable();
        }
    }

    void OnDisable()
    {
        foreach (var component in _components.Values)
        {
            component.OnDisable();
        }
    }

    private void AddComponent<T>() where T : IPlayerComponent
    {
        var type = typeof(T);

        object[] args = new object[] { this };

        var instance = (T)Activator.CreateInstance(type, args);
        _components[type] = instance;
    }

    public T GetPlayerComponent<T>() where T : IPlayerComponent
    {
        return (T)_components[typeof(T)];
    }
}
