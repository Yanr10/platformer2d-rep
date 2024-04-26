using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedRun;
    public float speed;
    public float forceJump = 2f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float scaleDuration = .3f;
    public float durationAnimation = 0.3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string triggerRun = "Run";
    public string triggerDeath = "Death";

}
