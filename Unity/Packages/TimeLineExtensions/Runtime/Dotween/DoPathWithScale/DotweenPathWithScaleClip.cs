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
    /// ��¶һ������
    /// </summary>
   public ExposedReference<DOTweenPath> doTweenPath ;
    public Vector3 scaleTo;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenPathWithScaleBehavior>.Create(graph, template);
        DotweenPathWithScaleBehavior clone = playable.GetBehaviour();
        clone.doTweenPath = doTweenPath.Resolve(graph.GetResolver());//��ͼ��߽�ѹ����
        clone.scaleTo = scaleTo;
        return playable;
    }
}
