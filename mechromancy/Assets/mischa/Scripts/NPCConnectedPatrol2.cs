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

        #region //private variables for base behaviour
        UnityEngine.AI.NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;
        #endregion

        bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;

        public string currentWaypointName; //debug ref

        // Start is called before the first frame update
        public void Start()
        {
            _navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
            //_navMeshAgent.updateRotation = false;

            #region //null nav mesh
            if (_navMeshAgent == null)
            {
                //Debug.LogError("nav mesh agent comp not attached to " + gameObject.name);
            }
            else
            {
                if (_currentWaypoint == null)
                {
                    //set at random
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint2"); //find all waypoints

                    if (allWaypoints.Length > 0)
                    {
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
                        //Debug.LogError("failed to find useable waypoints"); //show msg
                    }
                }

                SetDestination();
            }
            #endregion
        }

        private void Update()
        {
            #region //travelling
            //if (_travelling && _navMeshAgent.remainingDistance <= 2f) //if close to destination, 2 > 5 //error in rescaled, 0
            if (_travelling && Vector3.Distance(transform.position, _currentWaypoint.gameObject.transform.position) <= 300f)
            {
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
            #endregion

            #region //waiting
            if (_waiting) //if waiting, duration
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }
            }
            #endregion
            //Debug.Log(_navMeshAgent.remainingDistance);
            currentWaypointName = _currentWaypoint.name; //update target location
        }

        #region //set destination
        private void SetDestination()
        {
            if (_waypointsVisited > 0) //if waypoints visited
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint; //set previous as current
                _currentWaypoint = nextWaypoint; //set current as next
            }

            Vector3 targetVector = _currentWaypoint.transform.position; //set target to current waypoint location
            _navMeshAgent.SetDestination(targetVector); //set destination
            _travelling = true; //set to travelling
        }
        #endregion
    }
}