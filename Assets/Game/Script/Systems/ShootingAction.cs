




using UnityEngine;

public class ShootingAction {

     public static void Parse (ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings) {
        Vector3 cameraPosition = world.cam.transform.localPosition;
        Vector3 characterPos = world.penguinObj.transform.localPosition;

        float cameraUpperBound = cameraPosition.y + settings.cameraBounds.y;
        float cameraLowerBound = cameraPosition.y - settings.cameraBounds.y;
        float cameraRightBound = cameraPosition.x + settings.cameraBounds.x;
        float cameraLeftBound = cameraPosition.x - settings.cameraBounds.x;

        characterPos.y+= settings.penguinYUpPivotFix;

        int bulletPoolLen = world.bulletPool.Count;

        int activeBulletIndex = 0;

        // pick innactive bullet
        for (int i = 0; i< bulletPoolLen; i++){
            Bullet indexBullet = world.bulletPool[i];
            if(!indexBullet.active){
                activeBulletIndex = i;
                break;
            }
        }


        // ACTIVATE first inactive bullet
        if (controls.actionButton){
            world.bulletPool[activeBulletIndex].gameObject.SetActive(true);
            world.bulletPool[activeBulletIndex].active = true;
            world.bulletPool[activeBulletIndex].transform.localPosition = characterPos;
            world.bulletPool[activeBulletIndex].transform.localEulerAngles = new Vector3(0, 0, data.angleToMouse);

            data.xPush = -Mathf.Cos(data.angleToMouse * Mathf.Deg2Rad);
            data.gravity = -Mathf.Sin(data.angleToMouse * Mathf.Deg2Rad) * 3;
            world.spell2.Play();
        }


        // animate bullets
        for (int i = 0; i < bulletPoolLen; i++) {

            Bullet movingBullet = world.bulletPool[i];

            if (!movingBullet.active)
                continue;

            Vector3 bulletPosition = movingBullet.transform.localPosition;
            Vector3 bulletAngle = movingBullet.transform.localEulerAngles;

            Vector3 bulletMovement = new Vector3(Mathf.Cos(bulletAngle.z*Mathf.Deg2Rad), Mathf.Sin(bulletAngle.z * Mathf.Deg2Rad), 0); ;

            Vector3 newBulletPosition = bulletPosition + bulletMovement * delta.actionDelta * settings.bulletSpeed;

            movingBullet.transform.localPosition = newBulletPosition;
            bulletPosition = movingBullet.transform.localPosition;

            if (bulletPosition.x > cameraRightBound ||
                bulletPosition.x < cameraLeftBound ||
                bulletPosition.y > cameraUpperBound ||
                bulletPosition.y < cameraLowerBound) {
                movingBullet.gameObject.SetActive(false);
                movingBullet.active = false;
            }

        }

    }

}
