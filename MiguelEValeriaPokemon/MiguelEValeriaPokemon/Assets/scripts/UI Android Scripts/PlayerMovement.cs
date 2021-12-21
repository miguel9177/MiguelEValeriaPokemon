using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MasterClassExtensionMethod;
public class PlayerMovement : MonoBehaviour
{
    //this wil store the uiManager
    public UiManager uiManager;
    [SerializeField]
    float speed=5;
    //this will create a instance of the script automatically created by input actions
    private PlayerInputActions playerInputActions;
    //this is used to switch the active map, or edit a parameter from the player input from this object
    private PlayerInput playerInput;

    [SerializeField]
    //get the menu game object
    Menu pauseMenu;

    //this is true if the player is inside a trigger
    bool isTriggering;
    //this will save the last object that was triggered
    Collider2D objectTriggering;

    // Start is called before the first frame update
    void Start()
    {
        //this will get the player input thats on the inspector
        playerInput = GetComponent<PlayerInput>();
        //instantiate the variable
        playerInputActions = new PlayerInputActions();
        //this will swicth the action map
        SwitchActionMap("Player");
       
    }

    /// <summary>
    /// this function will change the current action map
    /// </summary>
    /// <param name="actionMapToChangeTo">UI or Player</param>
    public void SwitchActionMap(string actionMapToChangeTo)
    {
        //if i want to change the action map to ui, change it, if i want to player change
        switch (actionMapToChangeTo)
        {
            case "UI":
                playerInput.SwitchCurrentActionMap("UI");
                playerInputActions.Player.Disable();
                playerInputActions.UI.Enable();
                break;
            case "Player":
                playerInput.SwitchCurrentActionMap("Player");
                playerInputActions.Player.Enable();
                playerInputActions.UI.Disable();
                break;
        }

        Debug.Log(playerInput.currentActionMap);
    }

    //this is gonna be called when the action input happens, this is made on the player inputs, the callback context saves the information from the call, it has 3 phases pressed, hold and then release
    public void Action(InputAction.CallbackContext context)
    {
        if (context.performed)
        {  
            //if we are triggering 
            if(isTriggering==true && objectTriggering!=null)
            {
                //if the object triggering is a npc and he has a dialogue
                if(objectTriggering.gameObject.tag=="NPC" && objectTriggering.gameObject.GetComponent<DialogueManager>() == true)
                {
                    objectTriggering.gameObject.GetComponent<DialogueManager>().NextDialogue(this);
                    Debug.Log("Npc Talk Started" + objectTriggering.gameObject.name);
                }
            }
        }
        Debug.Log("Action" + context.phase);
    }

    //this will move the character by getting the left analogue position
    void MoveCharacter()
    {
        //Move the character using the vector 2 from left analogue
        MasterClassExtensionMethod.PhysicCodes.Movements.MovePositionRigidBody2D(this.gameObject, playerInputActions.Player.Movement.ReadValue<Vector2>(), speed);
    }
    public void PauseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseMenu.MenuPause();
        }
        
       
    }
    //this will be active when we are at a ui section
    public void UISubmit(InputAction.CallbackContext context)
    {
        Debug.Log("Ui Submit" + context.phase);
    }

    //this will return the Current Action Map
    public string ReturnCurrentActionMap()
    {
        return playerInput.currentActionMap.name;
    }

    //this will return the movement of the analogue while in UI Mode
    public Vector2 ReturnUiAnalogico()
    {
       return playerInputActions.UI.Movement.ReadValue<Vector2>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //say that the user is triggering and then save wich object is it
        isTriggering = true;
        objectTriggering = col;
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        //reset the triggering objects since we are no longer trigerring
        isTriggering = false;
        objectTriggering = null;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();    
    }
}
