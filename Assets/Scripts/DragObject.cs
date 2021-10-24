using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField]
    private Vector2 mousePosition;

    public Transform knifePlace;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public static bool used;

    public LayerMask Box;
    public GameObject Yellow;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Yellow.SetActive(false);
    }

    private void OnMouseDown(){
        if(!used){
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }
    private void OnMouseDrag(){
        if (!used){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp(){

        Vector2 RayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(RayPosition, Vector2.zero, 100, Box);

        if (hit.collider != null && hit.collider.gameObject.tag == "Box"){
            gameObject.SetActive(false);
            used = true;
            Yellow.SetActive(true);
            Debug.Log("cut box!");
        }
        else {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
            Debug.Log("not hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
