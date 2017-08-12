using UnityEngine;
using System.Collections;

public class DiplayController : MonoBehaviour {
    private Vector3 curMousePos;
    public Transform parentTrans;
    private bool mousePressed;

    float initialFingersDistance;
    Vector3 initialScale;

    Vector3 intialfingerPos;
    Vector3 initialPos;
    // Use this for initialization
    void Start()
    {
        curMousePos.z = Camera.main.transform.position.z; // should not be zero other wise camera position will the answer
       
    }
	
	// Update is called once per frame
	void Update () {
       
        UpdateDisplayPosition();
        ScaleObjects();


    }

    void UpdateDisplayPosition()
    {
        
        if (!mousePressed) return;
        curMousePos.x = Input.mousePosition.x;
        curMousePos.y= Input.mousePosition.y;
        curMousePos = Camera.main.ScreenToWorldPoint(curMousePos);
        curMousePos.z = parentTrans.position.z;
        this.transform.position = curMousePos;
    }
    void OnMouseDown()
    {
        mousePressed = true;
      
    }
    void OnMouseUp()
    {
        mousePressed = false;
    }

    void ScaleObjects()
    {
        int fingersOnScreen = 0;

        foreach (var touch in Input.touches)
        {
            fingersOnScreen++; //Count fingers (or rather touches) on screen as you iterate through all screen touches.

            //You need two fingers on screen to pinch.
            if (fingersOnScreen == 2)
            {

                //First set the initial distance between fingers so you can compare.
                if (touch.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    initialScale = transform.localScale;
                }
                else
                {
                    float currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

                    float scaleFactor = currentFingersDistance / initialFingersDistance;

                    transform.localScale = initialScale * scaleFactor;
                }
            }else if (fingersOnScreen == 1)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    intialfingerPos = Input.touches[0].position;
                   
                }
                else
                {
                    initialPos = Input.touches[0].position;
                    transform.position +=  (initialPos- intialfingerPos).normalized *0.1f;
                }
                 
            }
        }
    }
}
