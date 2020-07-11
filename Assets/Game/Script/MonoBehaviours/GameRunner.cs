
using UnityEngine;

public class GameRunner:MonoBehaviour {

    public World world;
    public Settings settings;
    
    Deltas delta;
    InputsManager controls;
    Data data;

    void Start () {

        // Init deltas for stability
        delta = new Deltas();
        delta.actionDelta = 1 / 60;
        delta.mainDelta = 1 / 60;

        //init inputs
        controls = new InputsManager();
        controls.movement = new Vector2();
        controls.pointer = new Vector2();

    }


    void Update () {

        DeltaTimeSystem.Parse(ref delta);

        // Will receive players input and modify controls
        InputReceiver.Parse(ref controls);
        
        CharacterActions.Parse(world,delta,controls);

        InputDeleter.Parse(ref controls);


    }



    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) { 
        if (data.disableControls)
            return;


    }


}
