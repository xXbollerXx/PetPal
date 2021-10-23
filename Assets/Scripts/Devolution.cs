using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Devolution : MonoBehaviour
{

    public float devolutionTicker = 1.0f; //Every X seconds, run the devolution function.
    public float nextTick = 0.0f;
    public animalTap animalTap;
    public GameplayManager gameplayManager; //To use CheckEvolutionState
    public int devolutionDelay = 5;

    void Update()
    {
        if (Time.time > nextTick)
        {
            nextTick += devolutionTicker;
            Devolve();
        }
    }

    void Devolve() {
        if (Time.time - animalTap.devolutionGracePeriod > devolutionDelay) 
        {
            animalTap.evolutionProgress -= gameplayManager.evolutions[gameplayManager.CheckEvolutionState()].evolutionDevolutionSpeed;
            animalTap.ChangeSize();
        }
    }

}
