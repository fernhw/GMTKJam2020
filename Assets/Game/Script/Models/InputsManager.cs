using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// All the input in the game.
/// </summary>

public class InputsManager
{

    //
    // Any button is true for Exclusively one frame
    //


    /// <summary>
    /// Axis X,Y
    /// </summary>
    public Vector2 movement;

  
    /// <summary>
    /// Axis X,Y
    /// </summary>
    public bool actionButton;

    /// <summary>
    /// A button makes the penguin make a sound
    /// </summary>
    public bool quak;

    /// <summary>
    /// X,Y towards the screen
    /// </summary>
    public Vector2 pointer;

    /// <summary>
    /// Click the screen
    /// </summary>
    public bool click;


}
