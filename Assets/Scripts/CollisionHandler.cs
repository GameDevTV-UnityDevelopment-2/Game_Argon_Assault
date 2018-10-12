using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("The delay before the scene is restarted, in seconds.")]
    [SerializeField]
    private float loadLevelDelay = 1f;

    [Tooltip("FX prefab on player")]
    [SerializeField]
    private GameObject deathFX;


    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");

        deathFX.SetActive(true);

        Invoke("ReloadScene", loadLevelDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}