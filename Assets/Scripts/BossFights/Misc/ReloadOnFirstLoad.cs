using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnFirstLoad : MonoBehaviour
{
    [Header("Train 1, Zeppelin 2, Skeleton 3")]
    [SerializeField] private int bossNumber;
    private static bool _trainReload;
    private static bool _zeppelinReload;
    private static bool _skeletonReload;
    void Awake()
    {
        switch (bossNumber)
        {
            case 1:
                if (!_trainReload)
                {
                    _trainReload = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            case 2:
                if (!_zeppelinReload)
                {
                    _zeppelinReload = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            case 3:
                if (!_skeletonReload)
                {
                    _skeletonReload = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
        }
    }
}
