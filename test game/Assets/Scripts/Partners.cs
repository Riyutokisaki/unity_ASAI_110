using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    [Header("�IĲ��H")]
    public GameObject player;
    [Header("���a��m")]
    public Transform plTransform;
    [Header("���ʳt��")]
    public float speed = 0.05f;
    [Header("�C���޲z")]
    public GameManager gameManager;
    [Header("�ʵe")]
    private Animator AN;//�p�٦�ʵe���
    public string walk = "����";
    public string jump = "���D";
    public string die = "���`";
    [Header("��ê��")]
    public GameObject box;
    [Header("�Ҧ��}��")]
    private bool story;
    [Header("��m�վ�"), Range(0, 10)]
    public float distance = 1.15f;

    #endregion
 
    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();//���o���������C���޲z
        Scene scene= SceneManager.GetActiveScene();//���o�����W��
        if (scene.name == "�G�ƼҦ�") story = true;//�p�G�����W�ٵ���"�G�ƼҦ�"bool�}��
        AN = GetComponent<Animator>();//��o�ʵe���
        player = GameObject.Find("�D��");//���o���a����
        plTransform = player.transform;//���o���a��m
        
        //tigger = GetComponent<Collider2D>().isTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("�I��F" + collision.gameObject.name);
        if (collision.gameObject.name == "�D��")//�p�G�I�쪺�O���a
        {
            AN.SetTrigger(jump);//������D�ʵe
            get = true;//�}��BOOL(����F�B��)
            GetPartners();//�I�s
        }
        if (collision.gameObject == box && get)//�Y�I���쪺GameObject�Obox�h
        {
            AN.SetTrigger(die);//���񦺤`�ʵe
            gameManager.GameOver();//�I�s�C���޲z�}GameOverUI

        }
        if (collision.gameObject.tag == "Finish" && get)//�Y�I���쪺GameObject�bFinish�ϼh(FOR�@��Ҧ�
        {
            AN.SetTrigger(die);
            gameManager.GameOver();

        }
    }
    private void FixedUpdate()
    {
        if (get)//�p�LGET�}�� ���ư���
        {
            GetPartners();
        }
        else if(!story)//�����d������G�ƼҦ�(�@��)�L�|���c�l����
        {
            Move();
        }
    }

    #region ��k
    void GetPartners()
    {
        //tigger=true;
        transform.position = new Vector3(plTransform.position.x - distance, plTransform.position.y, Time.deltaTime);//��m���ʨ쪱�a�᭱
        //RB.MovePosition(plTransform.position);
        float h = Input.GetAxis("Horizontal");
        if (h != 0) AN.SetTrigger(walk);//���ʰʵe����
        if (transform.position.y > 0) AN.SetTrigger(jump);//����@�w���׼�����D
       
    }

    void Move()
    {
        //�]�w���h�������J
        float h = Input.GetAxis("Horizontal");
        if (h > 0)//������J�j��0(���⩹�k)
        {
            transform.position += Vector3.left * speed;//�h��ê������m+=��m����*�t��
        }
        else if (h < 0)//������J�p��0(���⩹��)
        {
            transform.position += Vector3.right * speed;
        }
    }
    #endregion
}
