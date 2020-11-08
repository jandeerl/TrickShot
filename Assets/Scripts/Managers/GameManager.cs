using UnityEngine;

public class GameManager : MonoBehaviour,IEventSubscriber
{
    [SerializeField]
    private EventPublisher goalEvent;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject goalPrefab;

    private GameObject _goalObject;


    public int Score { get; private set; }

    private GoalObject goal;

    private void Awake()
    {
        goalEvent.Subscribe(this);
    }
    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        Score++;
        goal.MoveToRandomPosition();
    }

    public void StartGame()
    {
        inputManager.enabled = true;
        _goalObject = Instantiate(goalPrefab);
        goal = _goalObject.GetComponent<GoalObject>();
    }

}
