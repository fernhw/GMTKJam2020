using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningDetector
{
    public static void Parse (ref World world, ref Data data) {

    
        Vector3 penguinPosition = world.penguinObj.transform.localPosition;
        Vector3 endGameLimit = world.endGameSpawn.transform.localPosition;

        if (penguinPosition.x > endGameLimit.x) {
            data.gameEnd = true;
            Debug.Log("WINS GAME PENGUIN");
        }


    }
}
