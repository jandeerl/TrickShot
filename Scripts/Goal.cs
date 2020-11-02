using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Goal : MonoBehaviour
    { 
        [SerializeField]
        private OnGoalEvent goalEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //raise an event that will disable input and show end level menu
            goalEvent.Notify();
        }
    }
}