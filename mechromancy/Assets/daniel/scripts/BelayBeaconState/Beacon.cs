using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    //public bool isAttached;
    public Vector3 savePosition;
    
    //public Mesh mesh;
    
    public bool isSaved;
    [SerializeField]
    private Vector3 scale;
    
    private GameObject player;
    [HideInInspector]
    public MeshRenderer meshRenderer;

    public void Start()
    {
        player = FindObjectOfType<TitanfallMovement>().gameObject;
        meshRenderer = GetComponent<MeshRenderer>();
        
        //deactivate the mesh renderer to hide the beacon
        meshRenderer.enabled = false;

        //add listener on event manager
        EventManager.RegisterListener("save", save);
        EventManager.RegisterListener("load", load);
        EventManager.RegisterListener("cancle", Cancle);

        //scale the beacon
        GetComponentInParent<Transform>().localScale = scale;

        
    }

    public void Update()
    {
       
    }
    public void save() 
    {
        //Debug.Log("save message recieved");
        savePosition = this.gameObject.GetComponent<Transform>().position;
        meshRenderer.enabled = true;
        meshRenderer.material.SetColor("_Albedo", new Color(0.5f, 0.5f, 0.5f, 1));
        meshRenderer.material.SetFloat("_Transparency", 1f);
        isSaved = true;
    }

    public void Cancle() 
    {
        isSaved = false;
        meshRenderer.enabled = false;
    }

    IEnumerator Load() 
    {
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<Transform>().position = savePosition;
        meshRenderer.enabled = false;
        isSaved = false;
    }

    public void load() 
    {
        /*
        player.gameObject.GetComponent<Transform>().position = savePosition;
        meshRenderer.enabled = false;
        isSaved = false;
        */
        StartCoroutine(Load());
    }

   

    private void OnDestroy()
    {
        EventManager.UnregisterListener("save", save);
        EventManager.UnregisterListener("load", load);
        EventManager.UnregisterListener("cancle", Cancle);
    }
}
