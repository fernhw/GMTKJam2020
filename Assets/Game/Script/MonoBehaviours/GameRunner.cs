
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

        delta.mainDelta = Time.deltaTime;
        delta.actionDelta = Time.deltaTime /*modifier for SLOW MOTION PENGUINS*/;
                
        InputReceiver.Parse(ref controls);

        world.penguinObj.GameUpdate(delta,controls);





        //  world.penguinObj << penguin actions

    }



    public void ClickedData (string objectN, TypeOfTarget type, ClickedHack obj) { 
        if (data.disableControls)
            return;


    }


}
