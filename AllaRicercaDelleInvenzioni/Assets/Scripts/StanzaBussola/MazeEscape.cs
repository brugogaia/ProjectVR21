using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeEscape : MonoBehaviour
{
    [SerializeField] Transform _destination;
    private NavMeshAgent _navMeshAgent;
    private NavMeshPath _path;
    public float _speed = 1.0f;
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_navMeshAgent == null)
        {
            Debug.LogError("The NavMeshAgent is not attached to " + gameObject.name);
        }
        else
        {
            if (_destination != null)
            {
                _navMeshAgent.destination = _destination.position;
            }
        }

        _path = _navMeshAgent.path;
        
        Vector3 _targetDirection = _destination.position - transform.position;
        float _singleStep = _speed * Time.deltaTime;
        Vector3 _newDirection = Vector3.RotateTowards(transform.forward, _targetDirection, _singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(_newDirection);
    }
}
