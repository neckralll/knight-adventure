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

    private void Update() 
    {
        switch (_currentState) 
        {
            default:
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
        _startingPosition = transform.position;
        _roamPosition = GetRoamingPosition();
        ChangeFacingDirection(_startingPosition, _roamPosition);
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector3 GetRoamingPosition() => _startingPosition + Utils.GetRandomDirection() * Random.Range(roamingDistanceMin, roamingDistanceMax);

    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition) 
        => transform.rotation = sourcePosition.x > targetPosition.x ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

    private enum State 
    {
        Roaming
    }
}
