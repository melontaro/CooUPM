using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class DotweenMoveBehavior : PlayableBehaviour
{
    public Transform endLocation;
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
            float duration = (float)playable.GetDuration();
            doOnce = false;
            var actor = playerData as Transform;
            DOTween.To(() => actor.position, x => actor.position = x, endLocation.position, duration).SetEase(Ease.Linear);

        }
        else
        {
          //  Debug.LogError("0");

        }
    }
}
