using UnityEngine;

public class GameManager : MonoBehaviour,IEventSubscriber
{
    [SerializeField]
    private EventPublisher goalEvent;
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private EventPublisher _onPressingDown;
    [SerializeField]
    private EventPublisher _onReleaseInput;
    [SerializeField]
    private LineCoordinates _lineCoordinates;

    private GameObject _goalObject;
    private InputManager _inputManager;


    public int Score { get; private set; }
    public bool GameStarted { get; set; }

    private GoalObject goal;

    private void Awake()
    {
        goalEvent.Subscribe(this);
        InitializeInputManager();

    }
    private void InitializeInputManager()
    {
        _inputManager = gameObject.AddComponent<InputManager>();
        _inputManager.LineCoordinates = _lineCoordinates;
        _inputManager.OnPressingDown = _onPressingDown;
        _inputManager.OnReleaseInput = _onReleaseInput;
    }
    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        Score++;
        goal.MoveToRandomPosition();
    }

    public void StartGame()
    {
        _goalObject = Instantiate(goalPrefab);
        goal = _goalObject.GetComponent<GoalObject>();
        GameStarted = true;
    }

}
