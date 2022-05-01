using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon_controll : MonoBehaviour
{
    [SerializeField]
    private Beacon beacon; 
    private TitanfallMovement playerMomvement;
    private bool isContact;
    //private bool isGrounded;
    //[SerializeField]
    private float rayDistance;
    //[SerializeField]
    private int layerMask;
    private bool isSaved = false;
    private bool Moving = false;
    // Start is called before the first frame update
    void Start()
    {
        rayDistance = beacon.raycastDistance;
        layerMask = beacon.layerMask;
        playerMomvement = FindObjectOfType<TitanfallMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mouseScrollDelta);
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            save();
        }

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            load();
        }

        isMoving();
    }

    public bool groundDetect() 
    {
        isContact = playerMomvement.grounded;

        if (isContact)
        {
            RaycastHit hit;
            Physics.Raycast(GetComponentInParent<Transform>().position + new Vector3(0, 3, 0), Vector3.down, out hit, rayDistance, layerMask);
            if (hit.collider.gameObject.CompareTag("ground"))
            {
                return true;
            }
            else
                return false;
        }
        else return false;
    }

    public void save() 
    {
        if (playerMomvement.grounded && !Moving) 
        {
            EventManager.TriggerEvent("save");
            isSaved = true;
        }
    }

    public void load() 
    {
        if (isSaved) 
        {
            EventManager.TriggerEvent("load");
        }
    }

    private void isMoving() 
    {
        //Debug.Log(playerMomvement.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
        if (playerMomvement.gameObject.GetComponent<Rigidbody>().velocity.magnitude > .2f)
        {
            Moving = true;
        }
        else 
        {
            Moving = false;
        }
    }
}
