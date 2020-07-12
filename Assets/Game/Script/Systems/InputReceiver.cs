using ProInputSystem;
using UnityEngine;

public class InputReceiver {

    public static void Parse (Deltas delta,World world, ref InputsManager controls) {



        // Proprietary input system
        ProInput.UpdateInput(delta.mainDelta, true);

        AnalogueInput joystick = ProInput.GlobalActionStick;
        if (joystick.IsActive()) {
            float stickAngle = joystick.Angle;
            float stickCos = Mathf.Cos(stickAngle);
            float stickSin = Mathf.Sin(stickAngle);

            float realJoystickPress = ( joystick.Distance - joystick.DeadZone ) / ( 1 - joystick.DeadZone );
            controls.movement.x = stickCos;
            controls.movement.y = stickSin;
        } else {
            controls.movement.x = 0;
            controls.movement.y = 0;
        }

        
        // mouse pointer x and y
        Vector3 inputMouseRaw = Input.mousePosition;
        // Needed hack
        inputMouseRaw.z = 10;
        Vector3 mouse = world.cam.camera.ScreenToViewportPoint(inputMouseRaw);
        
        controls.pointer.x = mouse.x;
        controls.pointer.y = mouse.y;


        // You have to stop holding the action button to press it
        // For constant fire
        if (!controls.holdingActionButton) {
            controls.actionButton = ProInput.A;
        }
        if (ProInput.A) {
            controls.holdingActionButton = true;
        } else {
            controls.holdingActionButton = false;
        }

        if(controls.actionButton)
            Debug.Log("click");
    }

}