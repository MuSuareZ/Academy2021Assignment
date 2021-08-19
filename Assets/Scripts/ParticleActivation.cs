using UnityEngine;

public class ParticleActivation : MonoBehaviour
{
    public GameObject starExplosionPrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Instantiate(starExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}