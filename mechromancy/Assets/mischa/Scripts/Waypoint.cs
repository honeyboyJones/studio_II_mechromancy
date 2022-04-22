using UnityEngine;
using System.Collections;


public class Waypoint : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1.0f; //set gizmo radius

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red; //set gizmo colour
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius); //generate sphere
    }
}