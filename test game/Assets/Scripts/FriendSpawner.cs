using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    #region 欄位
    [Header("生成速度")]
    public float maxtime = 8f;
    private float timer = 0f;

    [Header("生成物件")]
    public GameObject[] friend;

    #endregion

    private void Awake()
    {
        GameObject newfriend = Instantiate(friend[Random.Range(0,6)]);//隨機實例化
        newfriend.transform.position = transform.position + new Vector3(0, -4, 0);//生成位置
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");//主角停止不動不生成
        if (timer > maxtime && h != 0)//如果經過時間>CD時間&&H不等於0
        {
            GameObject newfriend = Instantiate(friend[Random.Range(0, 6)]);//隨機實例化
            newfriend.transform.position = transform.position + new Vector3(0, -4, 0);//生成位置


            timer = 0;//歸零
        }
        timer += Time.deltaTime;
    }
}
