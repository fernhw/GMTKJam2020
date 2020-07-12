
using UnityEngine;


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

        //Todo: slow mo modifier in data for effects later
        DeltaTimeSystem.Parse(ref delta);
        GameStatusManager.Parse(ref world, ref data);

        // Will receive players input and modify controls
        InputReceiver.Parse(delta, world, ref controls);


        CalculateReticle.Parse(ref data, world, controls, settings);


        CharacterMovement.Parse(ref data, ref world, delta, controls, settings);

        CharacterActions.Parse(ref data,  world, controls);

        CameraMovement.Parse(ref data, ref world, delta, controls, settings);

        // clears input like buttons
        InputDeleter.Parse(ref controls);

    }



    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) { 
        if (data.disableControls)
            return;


    }


}
