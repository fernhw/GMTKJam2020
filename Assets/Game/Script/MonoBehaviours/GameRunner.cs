
using UnityEngine;

public class GameRunner:MonoBehaviour {

    public World world;
    public Settings settings;
    
    Deltas delta;
    InputsManager input;

    void Start () {

        // Init deltas for stability
        delta = new Deltas();
        delta.actionDelta = 1 / 60;
        delta.mainDelta = 1 / 60;

        //init inputs
        input = new InputsManager();
        input.movement = new Vector2();

    }


    void Update () {

        delta.mainDelta = Time.deltaTime;
        delta.actionDelta = Time.deltaTime /*modifier for SLOW MOTION PENGUINS*/;

        input.movement.x = Input.GetAxis("Horizontal");
        input.movement.y = Input.GetAxis("Vertical");

        world.penguinObj.GameUpdate(delta,input);

        //  world.penguinObj << penguin actions

    }



}
