using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventSubscriber {
    void PerformUpdate(IEventPublisher publisher);
}
