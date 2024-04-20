using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int sceneIndex;

    public void OpenScene()
    {
        if (HeartScript.health != HeartScript.MAX_HEALTH)
        {
            HeartScript.health = HeartScript.MAX_HEALTH;
            PlayerPrefs.SetFloat(HeartScript.HEALTH_KEY, HeartScript.MAX_HEALTH);
            PlayerPrefs.Save();
        }
        Debug.Log("màn"+sceneIndex);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
