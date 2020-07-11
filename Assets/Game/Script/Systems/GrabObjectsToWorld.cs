
using UnityEngine;

/// <summary>
/// For INIT (start) exclusively
/// </summary>
public class GrabObjectsToWorld:Object {
    public static void Parse (ref World world) {

        world.endGameSpawn = ( EndGameSpawn )FindObjectOfType(typeof(EndGameSpawn));
        world.gameStartingSpawn = ( GameStartingSpawn )FindObjectOfType(typeof(GameStartingSpawn));

        world.penguinObj = ( Movement )FindObjectOfType(typeof(Movement));
        world.cam = ( MainCamera )FindObjectOfType(typeof(MainCamera));

    }
}