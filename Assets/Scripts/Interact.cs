using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;
    public GameObject Knife;

    public GameObject Green;
    public GameObject Blue;
    public GameObject Red;

    public GameObject BlueKey;

    public bool getGreen = false;
    public bool getBlue = false;
    public bool getRed = false;

    public bool showBlueKey = false;

    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        Knife.SetActive(false);

        Green.SetActive(false);
        Blue.SetActive(false);
        Red.SetActive(false);

        BlueKey.SetActive(false);
        myText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);

            if (hit && hit.transform.tag == "interactable"){
                hit.transform.GetComponent<Interactable>().Interact(currentDisplay);
            }

            if (hit && hit.transform.tag == "KnifeCollectable"){
                Knife.SetActive(true);
            }
            if (hit && hit.transform.tag == "Plant"){
                Green.SetActive(true);
                getGreen = true;
                Debug.Log("Get Green!");
            }
            if (hit && hit.transform.tag == "Sofa"){
                Blue.SetActive(true);
                getBlue = true;
                Debug.Log("Get Blue!");
            }
            if (hit && hit.transform.tag == "Book"){
                Red.SetActive(true);
                getRed = true;
                Debug.Log("Get Red!");
            }
            if (hit && hit.transform.tag == "ActivateBlueKEy"){
                BlueKey.SetActive(true);
                //Debug.Log("Get Red!");
            }
            if (hit && hit.transform.tag == "YellowKey"){
                myText.gameObject.SetActive(true);
            }
        }

        if (showBlueKey == true){
            BlueKey.SetActive(true);
        }


    }
}
