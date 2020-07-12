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

    /// <summary>
    /// Camera position to spawn point
    /// </summary>
    public Vector3 CameraPositionToSpawnPoint = new Vector3();
    
    public float angleToMouse = 0;

    public float alienTimer = 0;
    
    public GameState gameStatus = GameState.GAME_ACTIVE;

    public bool disableControls = false;

    /// <summary>
    /// If game is in the exiting transition.
    /// !IMPORTANT input should be disabled 
    /// </summary>
    public bool gameEnd = false;

    public Vector3 goalCamPos = new Vector3();
    public Vector3 lerpedCameraPosition = new Vector3();

}
