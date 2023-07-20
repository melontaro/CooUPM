using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DotweenPathClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps => ClipCaps.Blending;


    private DotweenPathBehavior template = new DotweenPathBehavior();
    /// <summary>
    /// 暴露一个引用
    /// </summary>
   public ExposedReference<DOTweenPath> doTweenPath ;
  

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenPathBehavior>.Create(graph, template);
        DotweenPathBehavior clone = playable.GetBehaviour();
        clone.doTweenPath = doTweenPath.Resolve(graph.GetResolver());//从图里边解压出来
        return playable;
    }
}
