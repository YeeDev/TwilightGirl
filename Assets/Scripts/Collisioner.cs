using UnityEngine;
using UnityEngine.SceneManagement;
using TG.Abilities;

public class Collisioner : MonoBehaviour
{
    [SerializeField] string goalTag = "Goal";
    [SerializeField] string damagerTag = "Damager";
    [SerializeField] string spiderTag = "Spider";

    Vector3 startingPosition;
    PlaneSwapper swapper;

    private void Awake()
    {
        startingPosition = transform.position;
        swapper = GetComponent<PlaneSwapper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(goalTag))
        {
            int sceneToLoad = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(sceneToLoad);
        }

        if(other.CompareTag(damagerTag))
        {
            transform.position = startingPosition;
        }

        if (other.CompareTag(spiderTag))
        {
            if (swapper.InShadowRealm)
            {
                transform.position = startingPosition;
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
