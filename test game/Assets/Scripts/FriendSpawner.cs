
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    #region 欄位
    public float maxtime = 8f;
    private float timer = 0f;

    [Header("生成物件")]
    public GameObject[] friend;

    #endregion

    private void Awake()
    {
        GameObject newfriend = Instantiate(friend[Random.Range(0,6)]);
        newfriend.transform.position = transform.position + new Vector3(0, -4, 0);
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (timer > maxtime && h != 0)
        {
            GameObject newfriend = Instantiate(friend[Random.Range(0, 6)]);
            newfriend.transform.position = transform.position + new Vector3(0, -4, 0);


            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
