using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public animalTap animalTap;
    public Image animalImage;
    public bool isReset = false;

    //Need a list of objects for evolution stages. Define that here or maybe make a master controller/game manager?
    public Evolution[] evolutions;
    private int lastEvolutionState; //Used to track if the evolution state changes.

    public AudioSource evolutionSound0; //Not happy with this format but a bit short for time. Will try to turn into an array or using evolution.cs in v2
    public AudioSource evolutionSound1;
    public AudioSource evolutionSound2;
    public AudioSource evolutionSound3;

    void Update()
    {

    }


    public int CheckEvolutionState() //Returns the array position of the current evolution to make it easy to use elsewhere without writing out all this.
    {
        if (animalTap.evolutionProgress >= evolutions[3].evolutionIncrementalValue)
        {
            return 3;
        }
        else if (animalTap.evolutionProgress >= evolutions[2].evolutionIncrementalValue)
        {
            return 2;
        }
        else if (animalTap.evolutionProgress >= evolutions[1].evolutionIncrementalValue)
        {
            return 1;
        }
        else if (animalTap.evolutionProgress >= evolutions[0].evolutionIncrementalValue)
        {
            return 0;
        }
        else
        {
            return 0;
        }
    }

    public void CheckSize() //Update the sprite and speedDivider.
    {
        int evolutionStage = CheckEvolutionState();
        if (evolutionStage != lastEvolutionState) { //If it's changed...
            animalTap.animal.sprite = evolutions[evolutionStage].evolutionSprite;
            animalTap.speedDivider = evolutions[evolutionStage].evolutionSpeedDivider;
            switch (evolutionStage) {
                case 0:
                    evolutionSound0.Play();
                    break;
                case 1:
                    evolutionSound1.Play();
                    break;
                case 2:
                    evolutionSound2.Play();
                    break;
                case 3:
                    evolutionSound3.Play();
                    break;
            }
        }
        lastEvolutionState = evolutionStage;
    }


}
