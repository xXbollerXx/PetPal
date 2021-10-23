using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParticles : MonoBehaviour
{
    public ParticleSystem heartParticles;
    public ParticleSystem clickParticles;
    public Transform[] particleSpawnAreas;
    public Transform clickSpawnArea;


    public void SpawnParticles()
    {
        foreach(Transform p in particleSpawnAreas)
        {
            Instantiate(heartParticles, p);
            heartParticles.transform.localScale = p.localScale;
        }
        Instantiate(clickParticles, clickSpawnArea);
    }

}
