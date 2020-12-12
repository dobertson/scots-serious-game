using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  This script handles the WASD input for players moving around.
 *  It was lifted from this great youtube video https://www.youtube.com/watch?v=n-KX8AeGK7E
 */
public class PlayerMove : MonoBehaviour
{
    public string horizontalInputName;
    public string verticalInputName;
    public float walkingSpeed;
    public float sprintSpeed;
    private bool isSprinting;

    public float slopeForce;
    public float slopeForceRayLength;

    private CharacterController charController;

    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    public KeyCode jumpKey;
    private bool isJumping;

    public KeyCode sprintKey;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        isSprinting = false;
    }

    void ChangePos()
    {
        if (SceneManager.GetActiveScene().name == StringLiterals.TenementScene)
        {
            var sp = GameObject.FindGameObjectWithTag(StringLiterals.PlayerStatePositionsTag).GetComponent<SetupTenementScene>();
            //character controller issue would reset player position, fixed here https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/#post-4132021
            charController.enabled = false;
            transform.position = sp.GetPosition();
            transform.forward = sp.GetDirection();
            charController.enabled = true;
        }
    }

    void Start()
    {

    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName);
        float horizInput = Input.GetAxis(horizontalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //disable sprinting
        //SprintKey();

        if (isSprinting)
        {
            charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * sprintSpeed);
        }
        else
        {
            charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * walkingSpeed);
        }

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        JumpInput();
    }

    private void SprintKey()
    {
        if (Input.GetKey(sprintKey))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        isJumping = false;
        charController.slopeLimit = 45.0f;
    }

    private bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }
}
