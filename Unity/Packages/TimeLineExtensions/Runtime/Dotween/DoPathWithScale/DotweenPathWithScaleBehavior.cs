using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class DotweenPathWithScaleBehavior : PlayableBehaviour
{
    public DOTweenPath doTweenPath;
    public Vector3 scaleTo;
    bool doOnce = true;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
        Debug.LogError("OnBehaviourPlay: "+ doOnce);
        doOnce = true;
      
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
       if (doOnce)
        {
            doOnce = false;
            float duration = (float)playable.GetDuration();
        
            var actor = playerData as Transform;

            actor.DOPath(doTweenPath.path, duration,PathMode.Full3D);
            actor.DOScale(scaleTo, duration);

        }
        else
        {
          //  Debug.LogError("0");

        }
    }
}
