using UnityEngine;

public class WinCon1 : MonoBehaviour
{
    #region Variables
    [Header("Win Screens")]
    [SerializeField] private GameObject winScreen;
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.MasterKeyCardCollected)
        {
            GameManager.Instance.levelCompleted();
            winScreen.SetActive(true);
        }
    }
}
