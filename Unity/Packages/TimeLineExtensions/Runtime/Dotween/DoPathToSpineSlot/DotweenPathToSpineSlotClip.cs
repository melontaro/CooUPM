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
    /// ��¶һ������
    /// </summary>
   public ExposedReference<DOTweenPath> doTweenPath ;
    public ExposedReference<Transform> targetParent;


    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DotweenPathToSpineSlotBehavior>.Create(graph, template);
        DotweenPathToSpineSlotBehavior clone = playable.GetBehaviour();
        clone.doTweenPath = doTweenPath.Resolve(graph.GetResolver());//��ͼ��߽�ѹ����
      clone.  targetParent=targetParent.Resolve(graph.GetResolver());
        return playable;
    }
}
