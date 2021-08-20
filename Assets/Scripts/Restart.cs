using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void restartingGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
