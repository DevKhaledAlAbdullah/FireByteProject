using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MetaData.ConstVariable.GameSetting.Player))
        {
            GamePlayManagerScript.instance.Win();
            GamePlayManagerScript.instance.fireRedParticle.gameObject.SetActive(true);
            GamePlayManagerScript.instance.firePurpleParticle.gameObject.SetActive(true);
        }
    }
}
