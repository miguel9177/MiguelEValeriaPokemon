using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    //this will store all the canvas gameobjects, i use gameobjects to fix a bug from unity
    public GameObject pauseMenuCanvasGameObject;
    public GameObject battleCanvasGameObject;
    public GameObject playerCanvasGameObject;

    
    public void ShowPauseMenuCanvas()
    {
        //this will activate the pause menu canvas
        pauseMenuCanvasGameObject.gameObject.transform.localScale = new Vector2(1, 1);
        battleCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        playerCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
    }
    public void ShowBattleCanvas()
    {
        //this will activate the battle canvas
        pauseMenuCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        battleCanvasGameObject.gameObject.transform.localScale = new Vector2(1, 1);
        playerCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
    }

    public void ShowPlayerCanvas()
    {
        //this will activate the battle canvas
        pauseMenuCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        battleCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        playerCanvasGameObject.gameObject.transform.localScale = new Vector2(1, 1);

        //go trough every child of the player canvas and activate everything
        for (int i = 0; i < playerCanvasGameObject.transform.GetChild(0).transform.childCount; i++)
        {
            if(playerCanvasGameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<RectTransform>()==true)
            {
                playerCanvasGameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            }
        }
    }

    public void OnlyShowActionButton()
    {
        //this will activate the battle canvas
        pauseMenuCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        battleCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        playerCanvasGameObject.gameObject.transform.localScale = new Vector2(1, 1);

        //go trough every child of the player canvas and only activate the action button
        for (int i = 0; i < playerCanvasGameObject.transform.GetChild(0).transform.childCount; i++)
        {
            //if its the action button
            if(playerCanvasGameObject.transform.GetChild(0).GetChild(i).tag=="Action" || playerCanvasGameObject.transform.GetChild(0).GetChild(i).name == "Action")
            {
                playerCanvasGameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<RectTransform>().localScale = new Vector2(1, 1); 
            }
            else
            {
                playerCanvasGameObject.transform.GetChild(0).GetChild(i).gameObject.GetComponent<RectTransform>().localScale = new Vector2(0, 1);
            }
            
        }

    }

    public void HideEveryCanvas()
    {
        //this will activate the battle canvas
        pauseMenuCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
        battleCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1); 
        playerCanvasGameObject.gameObject.transform.localScale = new Vector2(0, 1);
    }
}
