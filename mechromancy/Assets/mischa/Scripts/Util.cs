using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathUtil //same function as libraries
{
    public class Util : MonoBehaviour
    {
        public static bool CanSeeObj(GameObject destination, GameObject origin, float range)
        {
            //dot product = angle beween 2 lines
            Vector3 dir = Vector3.Normalize(destination.transform.position - origin.transform.position); //normalise = magnitude, takes out length of a line; destination = find position between 2 vectors, origin = starting point, NPC/cube [give direction between 2 points]

            float angleDist = Vector3.Dot(origin.transform.forward, dir);

            //Debug.Log(angleDist); //show angleDist

            Debug.DrawRay(destination.transform.position, origin.transform.forward * 10, Color.red); //show red tracker, direction
            Debug.DrawRay(origin.transform.position, dir * 10, Color.green); //show green tracker, player origin

            if (angleDist > range) //if angle is higher/closer to line
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Vector3 ObjSide(GameObject destination, GameObject origin) //take npc forward direction + player direction in relation to npc, find crossproduct/perpendicular line, locate player in relation to npc (left/right)
        {
            Vector3 dir = Vector3.Normalize(destination.transform.position - origin.transform.position);
            Vector3 crossProd = Vector3.Cross(origin.transform.forward, dir);
            Debug.Log(crossProd);
            if (crossProd.y < 0)
            {
                Debug.Log(destination.name + " is left of " + origin.name);
            }
            else
            {
                Debug.Log(destination.name + " is right of " + origin.name);
            }
            return crossProd;
        }
    }
}