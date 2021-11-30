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
        Debug.Log(playerInput.currentActionMap);
    }

    /// <summary>
    /// this function will change the current action map
    /// </summary>
    /// <param name="actionMapToChangeTo">UI or Player</param>
    void SwitchActionMap(string actionMapToChangeTo)
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
    }

    //this is gonna be called when the jump input happens, this is made on the player inputs, the callback context saves the information from the call, it has 3 phases pressed, hold and then release
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        { Debug.Log("Jump that only is called once" + context.phase); }
        Debug.Log("Jump" + context.phase);
    }

    //this will be active when we are at a ui section
    public void UISubmit(InputAction.CallbackContext context)
    {
        Debug.Log("Ui Submit" + context.phase);
    }

    void MoveCharacter()
    {
        //Move the character using the vector 2 from left analogue
        MasterClassExtensionMethod.PhysicCodes.Movements.MovePositionRigidBody2D(this.gameObject, playerInputActions.Player.Movement.ReadValue<Vector2>(), speed);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();    
    }
}