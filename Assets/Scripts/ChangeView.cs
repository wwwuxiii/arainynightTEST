using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, Interactable
{
    public string SpriteName;

    public void Interact(DisplayImage currentDisplay){
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + SpriteName);
        currentDisplay.CurrentState = DisplayImage.State.ChangeView;

    }



    
}
