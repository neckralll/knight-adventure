using UnityEngine;
using UnityEngine.AI;
using KinghtAdventure.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax;
    [SerializeField] private float roamingDistanceMin;
    [SerializeField] private float roamingTimerMax;

    private NavMeshAgent _navMeshAgent;
    private State _currentState;
    private float _currentRoamingTime;
    private Vector3 _roamPosition;
    private Vector3 _startingPosition;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _currentState = startingState;
    }

    private void Start() 
    {
        _startingPosition = transform.position;
    }

    private void Update() 
    {
        switch (_currentState) 
        {
            default:
            case State.Idle:
                break;

            case State.Roaming:
                _currentRoamingTime -= Time.deltaTime;

                if (_currentRoamingTime < 0) 
                {
                    Roaming();
                    _currentRoamingTime = roamingTimerMax;
                }
                break;
        }
    }

    private void Roaming() 
    {
        _roamPosition = GetRoamingPosition();
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector3 GetRoamingPosition() => _startingPosition + Utils.GetRandomDirection() * Random.Range(roamingDistanceMin, roamingDistanceMax);

    private enum State 
    {
        Idle,
        Roaming
    }
}
