using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,IEventSubscriber
{
    [SerializeField]
    private OnGoalEvent goalEvent;
    [SerializeField]
    private InputManager manager;

    private void Awake()
    {
        goalEvent.Subscribe(this);
    }
    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        manager.enabled = false;
    }

}
