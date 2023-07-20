using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DotweenPathWithScaleClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps => ClipCaps.Blending;


    private DotweenPathWithScaleBehavior template = new DotweenPathWithScaleBehavior();
    /// <summary>
    /// 暴露一个引用
    /// </summary>
   public ExposedReference<DOTweenPath> doTweenPath ;
    public Vector3 scaleTo;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenPathWithScaleBehavior>.Create(graph, template);
        DotweenPathWithScaleBehavior clone = playable.GetBehaviour();
        clone.doTweenPath = doTweenPath.Resolve(graph.GetResolver());//从图里边解压出来
        clone.scaleTo = scaleTo;
        return playable;
    }
}
