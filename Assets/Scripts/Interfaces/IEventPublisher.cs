using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventPublisher
{
    void Subscribe(IEventSubscriber subscriber);
    void Unsubscribe(IEventSubscriber subscriber);
    void Notify();
}
