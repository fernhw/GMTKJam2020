

/// <summary>
/// All character actions worked from here
/// </summary>

using UnityEngine;

public class CharacterActions
{
    public static void Parse (ref Data data, World world, InputsManager controls, Settings settings, InputsManager input) {

        Vector3 characterPos = world.penguinObj.transform.localPosition;
        
        //Setting up angle from character
        //fixing penguin pivot so it's closer to the center
        characterPos.y += settings.penguinYUpPivotFix;
        data.characterPositionToCamera = world.cam.camera.WorldToViewportPoint(characterPos);
        data.characterToPointer.x = controls.pointer.x - data.characterPositionToCamera.x;
        data.characterToPointer.y = controls.pointer.y - data.characterPositionToCamera.y;
        data.angleToMouse = Mathf.Atan2(data.characterToPointer.y, data.characterToPointer.x) * Mathf.Rad2Deg;

        Debug.Log(data.angleToMouse);

        PenguinData charData = new PenguinData {
            wandAngle = data.angleToMouse
        };

        world.penguinObj.GameUpdate(charData, input);

    }
}
