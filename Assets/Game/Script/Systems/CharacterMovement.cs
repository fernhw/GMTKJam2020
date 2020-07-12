using UnityEngine;
using System.Collections;

public class CharacterMovement {

    public static void Parse (ref Data data,ref World world, Deltas delta, InputsManager controls, Settings settings) {

        Vector3 characterPos = world.penguinObj.transform.localPosition;

        characterPos.x += controls.movement.x * delta.actionDelta * settings.characterSpeed;

        world.penguinObj.transform.localPosition = characterPos;

    }

}
