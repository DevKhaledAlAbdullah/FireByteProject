using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUIScript : MonoBehaviour
{
    public void LoseLevel()
    {
        SceneManager.LoadScene(MetaData.ConstVariable.Scene.GameScene, LoadSceneMode.Single);
    }
}
