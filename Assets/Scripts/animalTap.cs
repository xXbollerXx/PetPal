using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//public class animalTap : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
//public class AnimalTap : MonoBehaviour, IPointerDownHandler
//public class AnimalTap : MonoBehaviour, IPointerDownHandler
public class animalTap : MonoBehaviour, IPointerDownHandler
{
    [Header("Animal properties/data")]
    public Image animal; //Set up the image and variables for starting size/the rate at which the object increases.

    [Header("Gameplay data")]
    public int speedDivider = 100; //added a speed divider so the sheep doesn't size too quick
    public float evolutionProgress;
    public float singleTapIncrease = 0.5f; //Making this a variable means it could be upgraded. Can also increase/reduce the starting value based on whatever we'd like (presumably this would reset when an evolution takes place)
    public float holdTapIncrease = 3.0f;
    public float tapTime = 0.6f;
    public GameplayManager gameplayManager;
    public ScoreManager scoreManager;
    public float devolutionGracePeriod; //Used to stop immediately devolving.
    public static animalTap Instance; //singleton instance (for the shop)

    private bool holdingClick = false; //Handle holding the mouse down vs just tapping.
    private float holdingTimeBeginning;
    
    private float startingX; //Allows for size to be reduced
    private float startingY;

    public AudioSource tapSound;


    // Update is called once per frame
    void Update()
    {
        if (holdingClick) { //If you started pressing the mouse...
            if (!Input.GetMouseButton(0)) { //then you stopped...
/*                if (Time.time - holdingTimeBeginning > tapTime) { evolutionProgress += holdTapIncrease; } //If you held it at least 0.6 seconds.
                else { evolutionProgress += singleTapIncrease; } //Or not
*/              evolutionProgress += singleTapIncrease; //This isn't that efficient but avoids removing the code to put the hold click back. 
                holdingClick = false; //Tell the game you're no longer holding the mouse.
                ChangeSize();  //Increase size.
            }
        }

    }

    void Start()
    {
        Vector2 animalSize = animal.rectTransform.sizeDelta;
        startingX = animalSize.x;
        startingY = animalSize.y;

        if (!Instance)
        {
            Instance = this;
        }
    }

    // Make sure to add a method (or add it to the pointer check) so that the particle effect is added.

    public void OnPointerDown(PointerEventData eventData)  //Start tapping the sprite.
    {
        holdingClick = true;
        holdingTimeBeginning = Time.time;
        tapSound.Play();
    }


    public void ChangeSize()  //Called to change the sprite size as well as updating score and running CheckSize() which updates sprite and speed divider.
    {
        devolutionGracePeriod = Time.time; //Can't devolve for the first 5 seconds.
        Vector2 animalSize = animal.rectTransform.sizeDelta;
        animal.rectTransform.sizeDelta = new Vector2(startingX + evolutionProgress / speedDivider, startingY + evolutionProgress / speedDivider);
        gameplayManager.CheckSize();  //Update sprite and speedDivider based on current evolution.
        scoreManager.UpdateScore(); //Update the score text.
        
    }

}
