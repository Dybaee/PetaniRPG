using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.InputReader.HealEvent += HealEvent;
        stateMachine.InputReader.TargetingEvent += OnTarget;
        stateMachine.InputReader.InteractEvent += OnInteract;
        stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }

        Vector3 movement = CalculateMovement();

        MovePlayer(movement * stateMachine.FreelookRunSpeed, deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1f, AnimatorDampTime, deltaTime);

        FaceMovementDirection(movement, deltaTime);
    }

    public override void ExitState()
    {
        stateMachine.InputReader.TargetingEvent -= OnTarget;
        stateMachine.InputReader.HealEvent -= HealEvent;
        stateMachine.InputReader.InteractEvent += OnInteract;

        stateMachine.SFXAudio.clip = null;
        stateMachine.SFXAudio.Stop();
    }

    private Vector3 CalculateMovement() 
    {
        // Camera forward and right variables
        Vector3 CamForward = stateMachine.MainCamTransform.forward;
        Vector3 CamRight = stateMachine.MainCamTransform.right;

        // Set the Y (up) value to 0
        CamForward.y = 0f;
        CamRight.y = 0f;

        // Normalize Camera variables
        CamForward.Normalize();
        CamRight.Normalize();

        // Combine the camera variables and MovementValue then return the result to UpdateState Method
        return CamForward * stateMachine.InputReader.MovementValue.y
            + CamRight * stateMachine.InputReader.MovementValue.x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationSmoothValue);
    }

    private void OnTarget()
    {
        if(!stateMachine.TargeterScript.SelectTarget()) { return; }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }

    private void HealEvent()
    {
        if (stateMachine.Health.currentHealth == 100 || stateMachine.Health.currentHealChances <= 0) {return; }
        stateMachine.SwitchState(new PlayerHealState(stateMachine));
    }

    private void OnInteract()
    {
        if(!stateMachine.DialogueTriggerScript.SelectNPC()) { return; }
        stateMachine.DialogueTriggerScript.dialogueScript.dialogBox.SetActive(true);
        stateMachine.SwitchState(new PlayerDialogueState(stateMachine));
    }
}
