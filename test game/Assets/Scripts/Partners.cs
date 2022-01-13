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
    public GameObject player;//�IĲ��H
    public Transform plTransform;
    public float speed = 0.05f;
    [Header("�I�줧�ᵥ�X��"), Range(0, 50)]
    public float waitTime = 0.5f;
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
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Scene scene= SceneManager.GetActiveScene();
        if (scene.name == "�G�ƼҦ�") story = true;
        AN = GetComponent<Animator>();
        player = GameObject.Find("�D��");
        plTransform = player.transform;
        
        //tigger = GetComponent<Collider2D>().isTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("�I��F" + collision.gameObject.name);
        if (collision.gameObject.name == "�D��")
        {
            AN.SetTrigger(jump);
            get = true;
            GetPartners();
        }
        if (collision.gameObject == box && get)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        {
            AN.SetTrigger(die);
            gameManager.GameOver();

        }
        if (collision.gameObject.tag == "Finish" && get)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        {
            AN.SetTrigger(die);
            
            gameManager.GameOver();

        }
    }
    private void FixedUpdate()
    {
        if (get)
        {
            GetPartners();
        }
        else if(!story)
        {
            Move();
        }
    }

    void GetPartners()
    {
        //tigger=true;
        transform.position = new Vector3(plTransform.position.x - distance, plTransform.position.y, Time.deltaTime);
        //RB.MovePosition(plTransform.position);
        float h = Input.GetAxis("Horizontal");
        if (h != 0) AN.SetTrigger(walk);
        if (transform.position.y > 0)
        {
            AN.SetTrigger(jump);
           
        }
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

}
