using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

  

    [Header("ADD PLAYER OBJECT THAT HAS PLAYER SCRIPT HERE")]
    [SerializeField]
    //this will get the player script
    PlayerMovement playerScript;
    [Header("add the Pause Menu GameObject here, the object to hide and show")]
    [SerializeField]
    //this will get the Pause Menu GameObject
    GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {    
        
    }

    //this will do the pause menu by switching the action map and activating the menu
    public void MenuPause()
    {
        if (PauseMenu.activeSelf == false)
        {
            //this will switch the action map to the ui
            playerScript.SwitchActionMap("UI");
            //make the first button be selected
            PauseMenu.transform.GetChild(0).GetComponent<Button>().Select();
            //get the first child AND ACTIVATES IT (menu ui)
            PauseMenu.SetActive(true);
        }
        else
        {
            //this will switch the action map to the Player
            playerScript.SwitchActionMap("Player");
            //get the first child and deactivate it
            PauseMenu.SetActive(false);
        }
        
    }
    

   

    // Update is called once per frame
    void Update()
    {
      
    }







    //MAKE THE NAVIGATION WORK WITH THE MOBILE JOISTICK manually
    /*void MenuPauseMoveOptions()
    {
        //if the current action map is UI and the pause menu is active
        if (playerScript.ReturnCurrentActionMap() == "UI" && PauseMenu.activeSelf == true)
        {
            //if the analogue is diagonal to the up and left
            if (playerScript.ReturnUiAnalogico().x <= -0.5f && playerScript.ReturnUiAnalogico().x >= -0.8f && playerScript.ReturnUiAnalogico().y > 0.3f)
            {
                //this will get the button on top and then it will select it
                currentSelectedButton = currentSelectedButton.FindSelectableOnUp().gameObject.GetComponent<Button>();
                currentSelectedButton = currentSelectedButton.FindSelectableOnLeft().gameObject.GetComponent<Button>();
                currentSelectedButton.FindSelectableOnLeft().Select();
               
            }
            //if the analogue is diagonal to the down and left
            else if (playerScript.ReturnUiAnalogico().x <= -0.5f && playerScript.ReturnUiAnalogico().x >= -0.8f && playerScript.ReturnUiAnalogico().y < -0.3f)
                Debug.Log("DOWN LEFT");
            //if the analogue is diagonal to the top and right
            else if (playerScript.ReturnUiAnalogico().x > 0.3f && playerScript.ReturnUiAnalogico().y >= 0.5f && playerScript.ReturnUiAnalogico().y <= 0.8f)
                Debug.Log("TOP RIGHT");
            //if the analogue is diagonal to the down and right
            else if (playerScript.ReturnUiAnalogico().x > 0.3f && playerScript.ReturnUiAnalogico().y <= -0.5f && playerScript.ReturnUiAnalogico().y <= -0.8f)
                Debug.Log("DOWN RIGHT");
            //if the analogue is top
            else if (playerScript.ReturnUiAnalogico().y >= 0.9f)
            {
                //this will get the button on top and then it will select it
                currentSelectedButton = currentSelectedButton.FindSelectableOnUp().gameObject.GetComponent<Button>();
                currentSelectedButton.FindSelectableOnUp().Select();
            }
            //if the analogue is down
            else if (playerScript.ReturnUiAnalogico().y <= -0.9f)
            {
                //this will get the button on down and then it will select it
                currentSelectedButton = currentSelectedButton.FindSelectableOnDown().gameObject.GetComponent<Button>();
                currentSelectedButton.FindSelectableOnDown().Select();
            }

            //if the analogue is right
            else if (playerScript.ReturnUiAnalogico().x >= 0.9f)
            {
                //this will get the button on right and then it will select it
                currentSelectedButton = currentSelectedButton.FindSelectableOnRight().gameObject.GetComponent<Button>();
                currentSelectedButton.FindSelectableOnRight().Select();
            }
            //if the analogue is left
            else if (playerScript.ReturnUiAnalogico().x <= -0.9f)
            {
                //this will get the button on left and then it will select it
                currentSelectedButton = currentSelectedButton.FindSelectableOnLeft().gameObject.GetComponent<Button>();
                currentSelectedButton.FindSelectableOnLeft().Select();
            }
        }    
    }*/
}
