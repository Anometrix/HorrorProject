using UnityEngine;

public class JonathanEnabler : MonoBehaviour
{
    #region Variables
    [Header("Objects")]
    [SerializeField] private GameObject jonathan;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jonathan.SetActive(true);
            Destroy(gameObject); // Destroy the trigger after activating Jonathan
        }
    }
}
