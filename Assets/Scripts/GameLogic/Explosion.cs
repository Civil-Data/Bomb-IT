using Assets.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedRenderer bombBeginning;
    public AnimatedRenderer bombMiddle;
    public AnimatedRenderer bombEnding;
    public void SetBombDirection(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.forward);
    }

    public void BombStageRender(AnimatedRenderer render)
    {
        bombBeginning.enabled = render == bombBeginning;
        bombMiddle.enabled = render == bombMiddle;
        bombEnding.enabled = render == bombEnding;
    }



}
