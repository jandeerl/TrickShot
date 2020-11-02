using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class GoalTrigger : MonoBehaviour
    { 
        [SerializeField]
        private EventPublisher goalEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            goalEvent.Notify();
        }       
    }
}