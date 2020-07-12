
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour {

    public World world;
    public Settings settings;
    
    Deltas delta;
    InputsManager controls;
    Data data = new Data();

    void Start () {

        ProInput.Init();

        GrabObjectsToWorld.Parse(ref world);

        WorldInit.Parse(ref world, ref data,ref delta, ref controls);

    }


    void Update () {

        if (( data.gameStatus == GameState.GAME_OVER || data.gameStatus == GameState.WINS_GAME ))
            return;

        //Todo: slow mo modifier in data for effects later
        DeltaTimeSystem.Parse(ref delta);
        GameStatusManager.Parse(ref world, ref data);

        // Will receive players input and modify controls
        InputReceiver.Parse(delta, world, ref controls);
        
        CalculateReticle.Parse(ref data, world, controls, settings);
        
        CharacterMovement.Parse(ref data, ref world, delta, controls, settings);

        ShootingAction.Parse(ref data, ref world, delta, controls, settings);

        EnemyAction.Parse(ref data, ref world, delta, controls, settings);

        CharacterActions.Parse(ref data,  world, controls, settings);
        
        CameraMovement.Parse(ref data, ref world, delta, controls, settings);
        CharacterLaunching.Parse(ref data, ref world, delta, controls, settings);

        // clears input like buttons
        InputDeleter.Parse(ref controls);

        if(data.gameStatus == GameState.GAME_OVER) {
            StartCoroutine(Death());
        }

        if (data.gameStatus == GameState.WINS_GAME) {
            StartCoroutine(Win());
        }

    }



    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) { 
        if (data.disableControls)
            return;


    }

    IEnumerator Death () {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Win () {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("EndGame");
    }


}
