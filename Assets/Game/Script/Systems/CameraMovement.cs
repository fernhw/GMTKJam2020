using UnityEngine;
using System.Collections;

public class CameraMovement {


    public static void Parse (ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings) {

        Vector3 characterPos = world.penguinObj.transform.localPosition;
        Vector3 camPos = world.cam.transform.localPosition;

        float camPosX = camPos.x;
        float camPosY = camPos.y;
        float camPosZ = camPos.z;


        float characterX = characterPos.x;
        float characterY = characterPos.y;


        data.goalCamPos = characterPos - data.CameraPositionToSpawnPoint;


        data.lerpedCameraPosition.x = camPosX + ( data.goalCamPos.x - camPosX ) * settings.cameraLerpSpeed.x * delta.actionDelta;
        data.lerpedCameraPosition.y = camPosY + ( data.goalCamPos.y - camPosY ) * settings.cameraLerpSpeed.y * delta.actionDelta;
        data.lerpedCameraPosition.z = camPosZ + ( data.goalCamPos.z - camPosZ ) * .1f * delta.actionDelta;

        if(data.lerpedCameraPosition.y > 2.4f) {
            data.lerpedCameraPosition.y = 2.4f;
        }

        if (data.lerpedCameraPosition.x < -1) {
            data.lerpedCameraPosition.x = -1f;
        }

        if (data.lerpedCameraPosition.x > 46) {
            data.lerpedCameraPosition.x = 46f;
        }
        
        world.cam.transform.localPosition = data.lerpedCameraPosition;

    }


}
