using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DotweenMoveClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps => ClipCaps.Blending;


    private DotweenMoveBehavior template = new DotweenMoveBehavior();
    /// <summary>
    /// 暴露一个引用
    /// </summary>
    public ExposedReference<Transform> EndLocation;
  

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenMoveBehavior>.Create(graph, template);
        DotweenMoveBehavior clone = playable.GetBehaviour();
        clone.endLocation = EndLocation.Resolve(graph.GetResolver());//从图里边解压出来
        return playable;
    }
}
