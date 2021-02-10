using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour
{
    // Start is called before the first frame update  
    [SerializeField] private GameObject _startObj;
    [SerializeField] private GameObject _endObj;
    private Vector3 _startingPoint;
    private Vector3 _endPoint;
    private Vector3 _previousCorner;
    private Vector3 _currentPosition;
    private Vector3 _minDist=Vector3.positiveInfinity;
    private Vector3 _directionToPoint;
    private NavMeshPath _path;
    private int i = 0;
    [SerializeField] private float timerReset;
    private float _originalTimer;


    void Start()
    {
        _originalTimer = timerReset;
        _path = new NavMeshPath(); 
        _startingPoint = _startObj.transform.position;
        _endPoint = _endObj.transform.position;
        NavMesh.CalculatePath(_startingPoint, _endPoint, NavMesh.AllAreas, _path);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _minDist2, _currentPosition2;

        _currentPosition = transform.position;

        timerReset -= Time.deltaTime;

        if (timerReset < 0f)
        {
            NavMesh.CalculatePath(_currentPosition, _endPoint, NavMesh.AllAreas, _path);
            Debug.Log("Reset");
            i = 0;
            timerReset = _originalTimer;
        }

        _minDist = _path.corners[i];

        //foreach (Vector3 corner in _path) {
        //    if (Vector3.Distance(_currentPosition, corner) < Vector3.Distance(_currentPosition, _minDist) && !Vector3.Equals(corner, _previousCorner)) {
        //        _minDist = corner;
        //    }
        //}

        _minDist2 = new Vector2(_minDist.x, _minDist.z);
        _currentPosition2 = new Vector2(_currentPosition.x, _currentPosition.z);

        if (Vector2.Distance(_currentPosition2, _minDist2) < 1.3f && i + 1 < _path.corners.Length)
        {
            //    _previousCorner = _minDist;
            //    _path[i++] = Vector3.positiveInfinity;
            timerReset = _originalTimer;
            i++;
        }
        
        _directionToPoint = new Vector3(_minDist.x - _currentPosition.x, 0 ,_minDist.z - _currentPosition.z);
        transform.forward= Vector3.RotateTowards(transform.forward, _directionToPoint, 0.1f, 0f);

        //_minDist = Vector3.positiveInfinity;
    }

}
