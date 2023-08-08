using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DotweenPathToSpineSlotClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps => ClipCaps.Blending;


    private DotweenPathToSpineSlotBehavior template = new DotweenPathToSpineSlotBehavior();
    /// <summary>
    /// 暴露一个引用
    /// </summary>
   public ExposedReference<DOTweenPath> doTweenPath ;
    public ExposedReference<Transform> targetParent;


    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenPathToSpineSlotBehavior>.Create(graph, template);
        DotweenPathToSpineSlotBehavior clone = playable.GetBehaviour();
        clone.doTweenPath = doTweenPath.Resolve(graph.GetResolver());//从图里边解压出来
      clone.  targetParent=targetParent.Resolve(graph.GetResolver());
        return playable;
    }
}
