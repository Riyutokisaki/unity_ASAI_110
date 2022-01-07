using UnityEngine;
using UnityEngine.Events;

/// <summary>
///��get��false(�٨S�J��player��)�b��a����(�ݻP�����@�P�ʧ@)
///�I��player�|�u�@�U
///��player�IĲ��B�ͮɡA�}get�����L��
///���B�͸��H��player���
///����X����player�ʧ@
///�ʵe�}��
/// </summary>
public class Partners : MonoBehaviour
{
    #region ���
    [Header("���!")]
    public bool get = false;//Player�I��S

    public GameObject player;//�IĲ��H
    public Transform plTransform;
    public float speed = 0.2f;


    private Animator AN;//�p�٦�ʵe���
    public string walk = "����";
    public string jump = "���D";
    public string die = "���`";

    private Rigidbody2D RB;

    #endregion

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AN = GetComponent<Animator>();
        player = GameObject.Find("Player");
        plTransform = player.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            AN.SetTrigger(jump);
            get = true;
            GetPartners();
        }
    }

    void GetPartners()
    {
        if (plTransform.position.x > transform.position.x)//���a��m�j��٦��m(�b����)
        {
            RB.velocity = new Vector2(plTransform.position.x, transform.position.y);
        }
    }
}
