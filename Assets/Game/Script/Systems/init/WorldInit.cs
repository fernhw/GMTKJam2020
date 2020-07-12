using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// inits the game, it's Object to access finders
/// </summary>
public class WorldInit:Object {
    public static void Parse (ref World world, ref Data data, ref Deltas delta, ref InputsManager controls) {

        //Setting Penguin birth (spawn)
        world.penguinObj.transform.localPosition = world.gameStartingSpawn.transform.localPosition;


        data = new Data();

        // Init deltas for stability
        delta = new Deltas {
            actionDelta = 1 / 60,
            mainDelta = 1 / 60
        };

        //init inputs
        controls = new InputsManager {
            movement = new Vector2(),
            pointer = new Vector2()
        };

    }
}