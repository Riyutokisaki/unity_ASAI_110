using UnityEngine;

/// <summary>
/// ���⪺���ʡB���D
/// </summary>
public class Characters: MonoBehaviour
{
    //���ʳt��
    public float MoveSpeed = 0.1f;

    #region ���D
    //�{�b�O�_�b���D
    public bool JumpingCheak = false;
    public float JumpForce;
    public Rigidbody2D JumpR;
    #endregion


    private void Update()
    {
        #region �樫
        //�]�ߤ@�Ӧs����m�T�������
        Vector2 CharactersPosition = transform.position;
        CharactersPosition.x = CharactersPosition.x + MoveSpeed * Input.GetAxis("Horizontal");
        transform.position = CharactersPosition;
        #endregion

        #region ���D
        JumpUp();

        void JumpUp()
        {
            if (Input.GetButtonDown("jump"))
            {
                JumpingCheak = true;
                Rigidbody2D.AddForce(Vector2.up * JumpForce);
            }
        }

        #endregion
    }


}
