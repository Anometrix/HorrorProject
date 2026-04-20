using UnityEngine;

public class CameraMovementMenu : MonoBehaviour
{
    #region Variables
    private bool finishedMoving = false;
    private bool beingUsed = false;

    [Header("Lerp Settings")]
    [SerializeField] private float lerpSpeed = 1f;
    private float lerpProgress = 0f; // camera movement progress
    private Vector3 startPos;
    private Vector3 endPos;

    // am big brain
    [Header("CameraMovement GameObjects")]
    [SerializeField] private Camera thisCamera;
    [SerializeField] private Camera otherCamera;
    [SerializeField] private GameObject wantedPos;
    [Header("Canvas GameObjects")]
    [SerializeField] private GameObject beginCanvas; // The Canvas thats active at the start
    [SerializeField] private GameObject mainMenuCanvas; // The Canvas for the actual main menu
    #endregion

    void Start()
    {
        startPos = thisCamera.transform.position;
        endPos = wantedPos.transform.position;
    }
    void Update()
    {
        if (beingUsed)
        {
            lerpProgress += Time.deltaTime * lerpSpeed;
            if (!finishedMoving)
            {
                this.transform.position = Vector3.Lerp(startPos, endPos, lerpProgress);
                if (lerpProgress >= 1f)
                {
                    otherCamera.gameObject.SetActive(true);
                    beginCanvas.SetActive(false);
                    mainMenuCanvas.SetActive(true);
                    thisCamera.gameObject.SetActive(false);
                    finishedMoving = true;
                    beingUsed = false;
                }
            }
        }
    }
    public void MoveCamera()
    {
        if (!beingUsed)
        {
            lerpProgress = 0f;
            beingUsed = true;
        }
    }
}
