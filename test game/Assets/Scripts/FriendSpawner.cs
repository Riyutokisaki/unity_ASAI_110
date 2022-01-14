using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    #region ���
    [Header("�ͦ��t��")]
    public float maxtime = 8f;
    private float timer = 0f;

    [Header("�ͦ�����")]
    public GameObject[] friend;

    #endregion

    private void Awake()
    {
        GameObject newfriend = Instantiate(friend[Random.Range(0,6)]);//�H����Ҥ�
        newfriend.transform.position = transform.position + new Vector3(0, -4, 0);//�ͦ���m
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");//�D������ʤ��ͦ�
        if (timer > maxtime && h != 0)//�p�G�g�L�ɶ�>CD�ɶ�&&H������0
        {
            GameObject newfriend = Instantiate(friend[Random.Range(0, 6)]);//�H����Ҥ�
            newfriend.transform.position = transform.position + new Vector3(0, -4, 0);//�ͦ���m


            timer = 0;//�k�s
        }
        timer += Time.deltaTime;
    }
}
