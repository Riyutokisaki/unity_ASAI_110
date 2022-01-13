using UnityEngine;


public class ReRunway : MonoBehaviour
{
    #region Дж¦м

    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    

 
}
