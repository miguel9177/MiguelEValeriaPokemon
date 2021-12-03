using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MasterClassExtensionMethod;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed=5;
    //this will create a instance of the script automatically created by input actions
    private PlayerInputActions playerInputActions;
    //this is used to switch the active map, or edit a parameter from the player input from this object
    private PlayerInput playerInput;

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
        { Debug.Log("Action that only is called once" + context.phase); }
        Debug.Log("Action" + context.phase);
    }
    void MoveCharacter()
    {
        //Move the character using the vector 2 from left analogue
        MasterClassExtensionMethod.PhysicCodes.Movements.MovePositionRigidBody2D(this.gameObject, playerInputActions.Player.Movement.ReadValue<Vector2>(), speed);
    }

    //this will be active when we are at a ui section
    public void UISubmit(InputAction.CallbackContext context)
    {
        Debug.Log("Ui Submit" + context.phase);
    }

    //this will return the movement of the analogue while in UI Mode
    public Vector2 UIMoveBetweenOpuions()
    {
       return playerInputActions.UI.Movement.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();    
    }
}
