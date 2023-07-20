using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[Serializable]
public class TransformClip : PlayableAsset,ITimelineClipAsset
{

    private TransformBehavior template=new TransformBehavior();
    /// <summary>
    /// 暴露一个引用
    /// </summary>
    public ExposedReference<Transform> EndLocation;
    public ClipCaps clipCaps { get { return ClipCaps.Blending; } }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TransformBehavior>.Create(graph, template);
        TransformBehavior clone=playable.GetBehaviour();
        clone.endLocation = EndLocation.Resolve(graph.GetResolver());//从图里边解压出来
        return playable;
    }
}
