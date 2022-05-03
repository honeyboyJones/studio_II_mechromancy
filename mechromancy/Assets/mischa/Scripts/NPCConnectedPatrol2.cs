using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class NPCConnectedPatrol2 : MonoBehaviour
    {
        [SerializeField] //dictates if agent waits on each node
        bool _patrolWaiting;

        [SerializeField] //total wait time @ each node
        float _totalWaitTime = 3f;

        [SerializeField] //probability of switching directions
        float _switchProbability = 0.2f;

        //private variables for base behaviour
        UnityEngine.AI.NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;

        bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;

        // Start is called before the first frame update
        public void Start()
        {
            _navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
            //_navMeshAgent.updateRotation = false;

            if (_navMeshAgent == null)
            {
                Debug.LogError("nav mesh agent comp not attached to " + gameObject.name);
            }
            else
            {
                if (_currentWaypoint == null)
                {
                    //set at random
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint2"); //find all waypoints

                    if (allWaypoints.Length > 0)
                    {
                        //Debug.Log("rkgfjze"); //check if waypoint length returns true/executes correctly
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length); //randomise
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                            if (startingWaypoint != null) //if not null
                            {
                                _currentWaypoint = startingWaypoint; //set current to starting
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("failed to find useable waypoints"); //show msg
                    }
                }

                SetDestination();
            }
        }

        private void Update()
        {
            if (_travelling && _navMeshAgent.remainingDistance <= 5.0f) //if close to destination, 2 > 5
            {
                Debug.Log("waypoint reached");
                _travelling = false;
                _waypointsVisited++;

                if (_patrolWaiting) //if going to wait
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    SetDestination();
                }
            }

            if (_waiting) //if waiting, duration
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }
            }
        }

        private void SetDestination()
        {
            if (_waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint;
                _currentWaypoint = nextWaypoint;
                Debug.Log("next waypoint " + nextWaypoint.name);
            }

            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }
}