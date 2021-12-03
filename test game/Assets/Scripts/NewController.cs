using UnityEngine;

/// <summary>
/// ���ⱱ�
/// </summary>

public class NewController : MonoBehaviour
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
    #endregion

    //���餸��
    private Rigidbody2D rig;
    //�ʵe����
    [SerializeField]
    private Animator an;
    //�N�p�H�����ܦb�ݩʭ��O(������)
    [SerializeField]
    //�O�_�b�a�W(�_)
    private bool isGrounded;

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
        rig.velocity = new Vector2(h * Speed, rig.velocity.y);//���餸��.�[�t�� �� �s��vector2(X�b�����k����ƭ�*�t��,�������[�t�ת�����y�ƭ�)

        //�� ������ ������0(!=0) �Ŀ飼��
        an.SetBool(Walk, h != 0);
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

        //���󤣦b�a�W�Ŀ���D
        an.SetBool(Up, !isGrounded);

    }
    /// <summary>
    /// ���D��k
    /// </summary>
    private void KeyJump()
    {
        //�p�G �b�a�O�W �B ���U����(�ť���)
        if (isGrounded && Input.GetKeyDown("space"))
        {
            //����W��(�b��즳�g).�K�[���O(�s���G���V�q(X.Y))(�V�W ��gY)
            rig.AddForce(new Vector2(0, Jump));
        }
    }

    #endregion
}
