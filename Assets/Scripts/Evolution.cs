using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EvolutionStage", menuName = "ScriptableObject/Evolutions", order = 1)]
public class Evolution : ScriptableObject
{
    [Header("Evolution Values")]
    public int evolutionStage;
    public int evolutionIncrementalValue;
    public int evolutionSpeedDivider;
    public float evolutionDevolutionSpeed;
    public Sprite evolutionSprite;

    [Header("Evolution Description")]
    [Space(20)]
    [TextArea(5, 10)]
    public string descriptionOfEvolution = "";   
}
