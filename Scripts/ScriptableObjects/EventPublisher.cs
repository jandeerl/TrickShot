using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventPublisher : ScriptableObject, IEventPublisher
{
    private List<IEventSubscriber> _subscribers = new List<IEventSubscriber>();

    public void Subscribe(IEventSubscriber subscriber)
    {
        if(!_subscribers.Contains(subscriber))
            _subscribers.Add(subscriber);
    }

    public void Unsubscribe(IEventSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (IEventSubscriber subscriber in _subscribers)
        {
            subscriber.PerformUpdate(this);
        }
    }


}
