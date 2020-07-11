using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data 
{
    public GameState gameStatus = GameState.GAME_ACTIVE;

    public bool disableControls = false;

    /// <summary>
    /// If game is in the exiting transition.
    /// !IMPORTANT input should be disabled 
    /// </summary>
    public bool gameEnd = false;

}
