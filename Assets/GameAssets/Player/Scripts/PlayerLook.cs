using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Variables
    [Header("Player Camera")]
    public Camera cam;
    private float xRotation = 0f;
    [Header("Sensitivity")]
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    #endregion

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        // Calculate the rotation based on mouse input and sensitivity
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80); // Clamp the vertical rotation to prevent flipping
        // apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // rotate the player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
