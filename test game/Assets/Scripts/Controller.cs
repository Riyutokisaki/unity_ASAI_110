using UnityEngine;

/// <summary>
/// ���ⱱ�
/// </summary>

public class Controller : MonoBehaviour
{
    #region ���}���
    [Header("���ʳt��"), Range(0,500)]
    public float Speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float Jump = 300f;
    [Header("�ˬd�a�O�ؤo�P�첾"), Range(0, 1)]
    public float CheckGroundRadius = 0.1f;
    public Vector3 CheckGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyJemp = KeyCode.Space;
    public LayerMask Layer;
    [Header("�ʵe�Ѽ�")]//�ʵe��������}��
    public string Walk = "isWalk";
    public string Up = "doTouch";
    public string Die = "���`";
    [Header("�C���޲z")]
    public GameManager gameManager;
    [Header("��ê��")]
    public GameObject box;
    [Header("�^����")]
    public GameObject backHome;
    [Header("�I�줧�ᵥ�X��"), Range(0, 50)]
    public float waitTime = 0.5f;
    [Header("����")]
    public AudioSource audio;
    public AudioClip shootAudio;

    #endregion

    #region �p�H���
    private Rigidbody2D rig;  //���餸��
    private Animator an;  //�ʵe����
    //[SerializeField]�N�p�H�����ܦb�ݩʭ��O(������)
    private bool isGrounded;//�O�_�b�a�W(�_)
    //[SerializeField]
    private int doubleJump =0;//���D����
    //[SerializeField]
    private bool speedRun;//���F��1���F��?
    //���ݰʵe����
    private float ANTime;
    private bool isDie;
    //��m�ե�
    private Vector3 set;
    #endregion
    /// <summary>
    /// ø�s�ϥ�
    /// �bunityø�s���U�ιϧ�
    /// �u���B�g�u�B��ΡB��ΡB�Ϥ�
    /// �ϥ� Gizmos ���O
    /// </summary>
    private void OnDrawGizmos()
    {
        //1.�M�w�C��
        //2.�M�wø�s�ϧ�
        //transform.position�����󪺥@�ɮy��
        Gizmos.color = new Color(1, 0, 0.2f,0.3f);
        Gizmos.DrawSphere(transform.position + 
           transform.TransformDirection(CheckGroundOffset), CheckGroundRadius);// transform.TransformDirection()�ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��

    }

    private void Start()
    {
        //�b�C���}�l��Ū�����󪺭���P�ʵe���
        rig = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        set = transform.position;
    }
   
    //Update ��60FPS
    //�T�w��s�ƥ�:50FPS
    //�B�z���z�欰
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
        CheckGround();
        KeyJump();
        if (isDie)
        {
            Wait();
        }
        
    }


    /// <summary>
    /// OnCollision(�I��)�POnTrigger(Ĳ�o)���P�b�s�g�ɭn�`�N
    /// 1.��Ӫ��󳣭n��Collider�B�䤤���@�n������(Rigidbody)����
    /// 2.�� "��" �Ŀ�IsTrigger
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //�PTrigger���P���ϥΦr��P�_�A�ӬO���wGameObject
        if (collision.gameObject == box)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        {
            an.SetTrigger(Die);
            isDie = true;

        }

        if (collision.gameObject == backHome)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        {
            gameManager.ButtonHome();//�I�sgameManager����Game��k
        }
    }

    # region ��k
    /// <summary>
    /// ���a�O�_����
    /// API Cassic Input GetAxis
    /// Vertical"����" Horizontal"����" 
    /// ��float
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); //�����J�ƭ�
        //rig.velocity = new Vector2(h * Speed, rig.velocity.y);//���餸��.�[�t�� �� �s��vector2(X�b�����k����ƭ�*�t��,�������[�t�ת�����y�ƭ�)

        //�� ������ ������0(!=0) �Ŀ飼��
        an.SetBool(Walk, h != 0);

        if (speedRun && h != 0 && Input.GetKeyDown("space"))
        {
            Speed++;
        }
        else if (h != 0 && Input.GetKeyDown("space"))
        {
            Speed = 5.5f;

            speedRun = true;
        }
        if (rig.velocity.x == 0)
        {
            Speed = 3.5f;

            speedRun = false;
        }
    }

    //½�� h<����Y�b����180 h>���ky����0
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }  
    
    private void CheckGround()
    {
        //����OnDrawGizmos�e�X�Ӫ��꦳�S���I��a�O
        //Physics2D-2D���� Circle���(2D)
        //�I����T = 2D ���z.�л\�ꫬ(�����I,�b�|,�ϼh)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
           transform.TransformDirection(CheckGroundOffset), CheckGroundRadius, Layer);
        //print("�I�쪺�ϼh" + hit.name);
        //�N���w�쪺���L��Ĳ�o(�O)
        isGrounded = hit;
        //�p�G����b�a�O�W ��G�q��Ĳ�o�k0
        if (isGrounded == true)
        {
            doubleJump = 0;
            if (transform.position.x>8.5f) transform.position = set;
        }
        //���󤣦b�a�W�Ŀ���D
        an.SetBool(Up, !isGrounded);
       
    }
    /// <summary>
    /// ���D��k
    /// </summary>
    private void KeyJump()
    {
        //�p�G (�G�q��Ĳ�o<2(���D����))�άO�b�a�O�W) �B ���U����(�ť���)
        if ((doubleJump <= 1 || isGrounded)&& Input.GetKeyDown("w"))
        {
            //����W��(�b��즳�g).�K�[���O(�s���G���V�q(X.Y))(�V�W ��gY)
            rig.AddForce(new Vector2(0, Jump));
            Play(shootAudio);
            doubleJump++ ;
        }
        
    }

    void Wait()
    {
        if (ANTime < waitTime)
        {
            ANTime += Time.deltaTime;
        }
        else
        {
            gameManager.GameOver();//�I�sgameManager����Game��k
        }

    }
    public void Play(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
    #endregion
}
