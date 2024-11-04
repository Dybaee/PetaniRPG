using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : PlayerBaseState
{
    private readonly int DialogueIdleHash = Animator.StringToHash("DialogueIdle");

    private const float CrossFadeDuration = 0.1f;
    public PlayerDialogueState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        stateMachine.DialogueTriggerScript.ToggleDialogue();
        stateMachine.Animator.CrossFadeInFixedTime(DialogueIdleHash, CrossFadeDuration);
        stateMachine.InputReader.CancelingEvent += OnCancel;
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        FaceToNPC();
        if (!stateMachine.DialogueTriggerScript.dialogueScript.isActive)
        {
            ReturnToAnyLocomotion();
        }
    }

    public override void ExitState()
    {
        stateMachine.InputReader.CancelingEvent += OnCancel;
    }

    private void OnCancel()
    {
        stateMachine.DialogueTriggerScript.dialogueScript.dialogBox.SetActive(false);
        stateMachine.DialogueTriggerScript.CancelNPC();
        ReturnToAnyLocomotion();
    }
}
