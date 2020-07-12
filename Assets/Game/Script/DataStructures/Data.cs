using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data structure for all
/// </summary>
public class Data 
{

    public Vector3 characterPositionToCamera = new Vector3();
    public Vector3 characterToPointer = new Vector3();

    public Vector3 initialDistanceToCamera = new Vector3();


    public float angleToMouse = 0;


    public GameState gameStatus = GameState.GAME_ACTIVE;

    public bool disableControls = false;

    /// <summary>
    /// If game is in the exiting transition.
    /// !IMPORTANT input should be disabled 
    /// </summary>
    public bool gameEnd = false;



}
