using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform deathFXParent;
    [SerializeField] private int scoringValue;
    [SerializeField] private int hits = 10;

    private ScoreBoard scoreBoard;


    private void Start()
    {
        AddBoxCollider();

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();

        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hits <= 0)
        {
            Destroyed();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.IncrementScore(scoringValue);

        hits--;
    }

    private void Destroyed()
    {
        GameObject fx = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParent;

        Destroy(gameObject);
    }
}