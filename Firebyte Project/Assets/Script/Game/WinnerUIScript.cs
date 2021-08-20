using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerUIScript : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(MetaData.ConstVariable.Scene.GameScene, LoadSceneMode.Single);
    }
}
