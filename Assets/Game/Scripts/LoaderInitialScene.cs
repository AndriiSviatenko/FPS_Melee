using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderInitialScene : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadInitialScene()
    {
        SceneManager.LoadScene(0);
    }
}
