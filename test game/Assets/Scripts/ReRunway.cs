using UnityEngine;


public class ReRunway : MonoBehaviour
{
    #region ���

    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    

 
}
