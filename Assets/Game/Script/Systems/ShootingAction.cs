




using UnityEngine;

public class ShootingAction {

     public static void Parse (ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings) {

        Vector3 characterPos = world.penguinObj.transform.localPosition;
        characterPos.y+= settings.penguinYUpPivotFix;

        int bulletPoolLen = world.bulletPool.Count;
        Bullet currentBullet;

        // pick innactive bullet
        for (int i = 0; i< bulletPoolLen; i++){
            Bullet indexBullet;
            if(!indexBullet.active){
                currentBullet = indexBullet;
                break;
            }
        }

        // animate bullets
            

        if(controls.actionButton){
            world.bulletPool[0].transform.localPosition = characterPos;
        }

    }

}
