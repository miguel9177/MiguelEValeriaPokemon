using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class UIScaleWithScreen : MonoBehaviour
{
    // Set this to the in-world distance between the left & right edges of your scene.
    public float ammountToDivideByScreenWidth = 10;


    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {        
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / ammountToDivideByScreenWidth, Screen.width / ammountToDivideByScreenWidth);   
    }
}
