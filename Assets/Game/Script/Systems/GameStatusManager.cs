

using UnityEngine;

public class GameStatusManager {
    public static void Parse (ref World world, ref Data data) {


        // Are controls disabled?
        switch (data.gameStatus) {
        case GameState.CUTSCENE:
        case GameState.PAUSED:
        case GameState.WINS_GAME:
        data.disableControls = true;
        break;
        case GameState.GAME_ACTIVE:
        data.disableControls = false;
        break;
        }


    }
}
