
using UnityEngine;

public class GameRunner : MonoBehaviour {

    public World world;
    public Settings settings;
    
    Deltas delta;
    InputsManager controls;
    Data data = new Data();

    void Start () {

        GrabObjectsToWorld.Parse(ref world);

        WorldInit.Parse(ref world, ref data,ref delta, ref controls);

    }


    void Update () {

        GameStatusManager.Parse(ref world, ref data);

        // Will receive players input and modify controls
        InputReceiver.Parse(ref controls);
        
        //Todo: slow mo modifier in data for effects later
        DeltaTimeSystem.Parse(ref delta);


        //Todo: all actionable stuff
        CharacterActions.Parse(world,delta,controls);

        InputDeleter.Parse(ref controls);

    }



    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) { 
        if (data.disableControls)
            return;


    }


}
