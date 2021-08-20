using UnityEngine;

public class ObestacleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(MetaData.ConstVariable.GameSetting.Player))
        { 
            Destroy(this.gameObject, 1);
        }
        
    }
}
