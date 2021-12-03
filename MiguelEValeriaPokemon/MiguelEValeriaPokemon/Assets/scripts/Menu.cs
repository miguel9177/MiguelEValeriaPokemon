using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //ACABAR ESTE SCRIPT, BASICAMENTE V BUSCAR O VALOR DO ANALOGICO EM UI E DEPOIS MUDO O SELECTED
        PauseMenu.transform.GetChild(0).GetComponent<Button>().Select();
        PauseMenu.transform.GetChild(0).GetComponent<Button>().FindSelectableOnDown().Select();
        playerScript.UIMoveBetweenOpuions();
    }

    //this will do the pause menu by switching the action map and activating the menu
    public void MenuPause()
    {
        if (PauseMenu.activeSelf == false)
        {
            //this will switch the action map to the ui
            playerScript.SwitchActionMap("UI");
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
        //MAKE THE NAVIGATION WORK WITH THE MOBILE JOISTICK, UNITY ALREADY HAS THE NAVIGATION OFF THE BUTTONS, NOW I JUST NEED TO REACH THEM

    // Update is called once per frame
    void Update()
    {
        
    }
}
