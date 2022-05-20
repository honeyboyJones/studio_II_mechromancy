using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
    public Vector3 collisionPosition;
    public Vector3 collisionNormal;
    public bool isColliding;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(collisionPosition);
    }

    private void OnParticleCollision(GameObject other)
    {
        int collisionNum = particle.GetCollisionEvents(other, particleCollisionEvents);
      
        for (int i = 0; i < collisionNum; i++) 
        {
            ParticleCollisionEvent collision = particleCollisionEvents[i];
            collisionPosition = collision.intersection;
            collisionNormal = collision.normal;
            
        }
    }
    public void ParticleBegin() 
    {
        particle.Play();
    }

    public void ParticlePause() 
    {
        particle.Pause();
        particle.Clear();
    }
}
