using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EventPublisher_Object", menuName ="Scriptable Objects/Event Publisher")]
public class EventPublisher : ScriptableObject, IEventPublisher
{
    private List<IEventSubscriber> subscribers = new List<IEventSubscriber>();

    public void Subscribe(IEventSubscriber subscriber)
    {
        if(!subscribers.Contains(subscriber))
            subscribers.Add(subscriber);
    }

    public void Unsubscribe(IEventSubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (IEventSubscriber subscriber in subscribers)
        {
            subscriber.PerformUpdate(this);
        }
    }


}
