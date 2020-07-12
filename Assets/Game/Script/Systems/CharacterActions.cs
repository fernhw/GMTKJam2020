﻿


/// <summary>
/// All character actions worked from here
/// </summary>

using UnityEngine;

public class CharacterActions
{
    public static void Parse (ref Data data, World world , InputsManager input, Settings settings) {

        // moved to calculatereticle.cs

        PenguinData charData = new PenguinData {
            wandAngle = data.angleToMouse
        };

        world.penguinObj.GameUpdate(charData, input,ref data, settings, world);

    }
}
