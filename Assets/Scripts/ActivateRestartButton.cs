using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateRestartButton : MonoBehaviour
{
    private Collision col;

    public Button button;
    public GameObject player;

    void Start()
    {
        button.gameObject.SetActive(false);
    }


    void Update()
    {
        col = player.GetComponent<Collision>();
        if (col.isGameOver == true)
        {
            StartCoroutine(ButtonDelay());
        }
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(2);
        button.gameObject.SetActive(true);
    }
}
