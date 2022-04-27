using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    //public bool isAttached;
    public Vector3 savePosition;
    public Quaternion saveRotation;
    public Mesh mesh;
    public float raycastDistance;
    public int layerMask;
    [SerializeField]
    private Vector3 scale;
    private Vector3 PlayerPos;
    private Quaternion playerRotation;
    private GameObject player;
    private MeshRenderer meshRenderer;

    public void Start()
    {
        player = FindObjectOfType<TitanfallMovement>().gameObject;
        meshRenderer = GetComponent<MeshRenderer>();
        
        //deactivate the mesh renderer to hide the beacon
        meshRenderer.enabled = false;

        //add listener on event manager
        EventManager.RegisterListener("save", save);
        EventManager.RegisterListener("load", load);

        //scale the beacon
        GetComponentInParent<Transform>().localScale = scale;

        layerMask = ~layerMask;
    }

    public void Update()
    {
        PlayerPos = player.GetComponent<Transform>().position;
        playerRotation = player.GetComponent<Transform>().rotation;
    }
    public void save() 
    {
        //set the beacon's position according to the raycast result
        this.GetComponentInParent<Transform>().position = groudDetect(PlayerPos);
        meshRenderer.enabled = true;
        savePosition = PlayerPos;
        saveRotation = playerRotation;
    }

    public void load() 
    {
        //player.GetComponent<Transform>().Translate(player.GetComponent<Transform>().position-savePosition);
        player.GetComponent<Transform>().position = savePosition;
        player.GetComponent<Transform>().rotation = saveRotation;
        meshRenderer.enabled = false;
    }

    public Vector3 groudDetect(Vector3 player_pos) 
    {
        //cast a ray from player pos to determine where this beacon should be placed
        RaycastHit hit;
        Physics.Raycast(player_pos + new Vector3(0, 3, 0), Vector3.down, out hit, raycastDistance, layerMask);

        //return raycast hit point postion
        return hit.point;
        //Debug.Log(hit.point);
    }

    private void OnDestroy()
    {
        EventManager.UnregisterListener("save", save);
        EventManager.UnregisterListener("load", load);
    }
}
