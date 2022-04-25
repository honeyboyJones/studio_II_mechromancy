using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]

public class AnimRotation : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform waypoints;

    [SerializeField]
    private float moveSpeed = 2.0f;

    Vector3 getInput;

    #region //attempt 1
    //public Transform rotating;
    //public float bodyOrb;
    //public float bodyWeight;
    //private Animator animator;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //private void OnAnimatorIK(int layerIndex)
    //{
    //    animator.SetLookAtPosition(rotating.position);
    //    animator.SetLookAtWeight(1, bodyOrb, bodyWeight);
    //}
    #endregion

    #region //attempt 2
    //private void FixedUpdate()
    //{
    //    GetComponent<Rigidbody>().velocity = getInput * moveSpeed; //locate rb comp, set velocity

    //    Vector3 lookPos = new Vector3(
    //            transform.position.x + GetComponent<Rigidbody>().velocity.x,
    //            transform.position.y,
    //            transform.position.z + GetComponent<Rigidbody>().velocity.z
    //        );
    //    transform.LookAt(lookPos);
    //}
    #endregion

    #region //attempt 3
    //// The target marker.
    //public Transform target;

    //// Angular speed in radians per sec.
    //public float speed = 1.0f;

    //void Update()
    //{
    //    // Determine which direction to rotate towards
    //    Vector3 targetDirection = target.position - transform.position;

    //    // The step size is equal to speed times frame time.
    //    float singleStep = speed * Time.deltaTime;

    //    // Rotate the forward vector towards the target direction by one step
    //    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

    //    // Draw a ray pointing at our target in
    //    Debug.DrawRay(transform.position, newDirection, Color.red);

    //    // Calculate a rotation a step closer to the target and applies rotation to this object
    //    transform.rotation = Quaternion.LookRotation(newDirection);
    //}
    #endregion

    #region //attempt 4
    //private void Awake()
    //{
    //    waypoints = GameObject.Find("Waypoint").transform;
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //}
    #endregion
}
