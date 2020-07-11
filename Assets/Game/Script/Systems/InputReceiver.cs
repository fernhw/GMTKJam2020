using UnityEngine;

public class InputReceiver {
    
    public static void Parse (ref InputsManager controls) {

        controls.movement.x = Input.GetAxis("Horizontal");
        controls.movement.y = Input.GetAxis("Vertical");

      //  mouse pointer x and y
        Vector3 mouse = Input.mousePosition;
        controls.pointer.x = mouse.x;
        controls.pointer.y = mouse.y;

    }

}