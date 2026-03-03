using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region Variables
    private CharacterController controller;
    private Vector3 playerVelocity;
    [Header("Movement")]
    public float speed;
    private bool crouching = false;
    private float crouchTimer = 1;
    private bool lerpCrouch = false;
    private bool sprinting = false;
    #endregion

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p; // Ease in and out the crouch transition
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p); // Half the height of the player when crouching
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p); // Normal height of the player when not crouching
            }

            if (p > 1)
            {
                lerpCrouch = false; // Stop lerping once the transition is complete
                crouchTimer = 0;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); // Move the player based on input and speed
    }
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }
}