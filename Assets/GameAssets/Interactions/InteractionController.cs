using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    [SerializeField] TextMeshProUGUI interactionText;

    [SerializeField] float interactionDistance = 3f;

    IIenteractable currentTargetedInteractable;

    public void Update()
    {
        UpdateCurrentInteractable();

        UpdateInteractionText();

        CheckForInteractionInput();
    }
    void UpdateCurrentInteractable()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2 (0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactionDistance);

        currentTargetedInteractable = hit.collider?.GetComponent<IIenteractable>();
    }
    void UpdateInteractionText()
    {
        if (currentTargetedInteractable == null)
        {
            interactionText.text = string.Empty;
            return;
        }

        interactionText.text =  currentTargetedInteractable.InteractMessage;
    }
    void CheckForInteractionInput()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && currentTargetedInteractable != null)
        {
            currentTargetedInteractable.Interact();
        }
    }
}
