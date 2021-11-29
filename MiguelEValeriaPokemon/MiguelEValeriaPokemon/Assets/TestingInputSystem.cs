using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        //this line is for gonna call the function every input action done
        //playerInput.onActionTriggered += PlayerInput_onActionTriggered;

        //this 3 lines will be called when jump happens, this doesnt need the player input on the inspector, because its gonna create a new istamnce of it
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        //this subscribes toi the jump function from player input, so now the jump function from this sript will be called when we click space
        playerInputActions.Player.Jump.performed += Jump;


      
    }

    //this receives every actions and needs to have receive unity csharp events on the player input
   /* private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }*/

    //this is gonna be called when the jump input happens, this is made on the player inputs, the callback context saves the information from the call, it has 3 phases pressed, hold and then release
    //this is a unity event meaning its called on the inspector, to activate it, just go to the inspector, player input, set the behaviour to invoke unity events, then with the default map selected to player, go to events - > player - > jump, and set it to this function
    //this doesnt need any variables its just this function and it works
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        { Debug.Log("Jump that only is called once" + context.phase); }
        Debug.Log("Jump" + context.phase);
    }

    public void UISubmit(InputAction.CallbackContext context)
    {
        Debug.Log("Ui Submit" + context.phase);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        //if t is pressed switch current action map to ui
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("UI");
            playerInputActions.Player.Disable();
            playerInputActions.UI.Enable();
        }

        //if y is pressed switch current action map to player
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("Player");
            playerInputActions.Player.Enable();
            playerInputActions.UI.Disable();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //see the movement on every frame to move
        Debug.Log(playerInputActions.Player.Movement.ReadValue<Vector2>());
    }
}
