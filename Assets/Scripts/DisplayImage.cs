using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State{
        normal, zoom, ChangeView
    };

    public State CurrentState{ get; set; }

    public int CurrentWall{
        get {return currentWall;}
        set {
            if (value == 4)
            currentWall = 1;
            else if (value == 0)
            currentWall = 3;
            else
            currentWall = value;
        }
    }
    private int currentWall;
    private int previousWall;

    void Start(){
        previousWall = 0;
        currentWall = 1;
    }

    void Update(){
        if (currentWall != previousWall){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }

}
