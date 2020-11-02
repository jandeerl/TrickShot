using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,IEventSubscriber
{
    [SerializeField]
    private EventPublisher goalEvent;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject goalPrefab;

    private GameObject goalObject;


    public int score = 0;

    private GoalObject goal;

    private void Awake()
    {
        goalEvent.Subscribe(this);
    }
    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        score++;
        goal.MoveToRandomPosition();
    }

    public void StartGame()
    {
        inputManager.enabled = true;
        goalObject = Instantiate(goalPrefab);
        goal = goalObject.GetComponent<GoalObject>();
    }

}
