using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "OnPressingDownEvent", menuName = "ScriptableObjects/Pressing Down Object")]
public class OnPressingDownEvent : EventPublisher
{
    public Action onReleased;
    
}
