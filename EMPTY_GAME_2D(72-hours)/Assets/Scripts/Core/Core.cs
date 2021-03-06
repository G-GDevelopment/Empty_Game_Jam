using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    public Ability Ability { get; private set; }
    public PlayerAudio PlayerAudio { get; private set; }
    public Animator Anim { get; private set; }

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Ability = GetComponentInChildren<Ability>();
        PlayerAudio = GetComponentInChildren<PlayerAudio>();
        Anim = GetComponentInParent<Animator>();
        if (!Movement || !CollisionSenses || !Ability || !PlayerAudio)
        {
            Debug.Log("Missing Core Components");
        }

        if (!Anim)
        {
            Debug.Log("Missing Animator Component");
        }
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        CollisionSenses.LogicUpdate();
        Ability.LogicUpdate();
    }
}
