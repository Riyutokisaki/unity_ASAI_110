using UnityEngine;

/// <summary>
/// ���⪺���ʡB���D
/// </summary>
public class Characters: MonoBehaviour
{
    //���ʳt��
    public float MoveSpeed = 0.1f;
    public Transform MoveT;

    #region ���D
    public bool JumpingCheak = false;
    public float JumpForce = 5f;
    public Rigidbody2D JumpR;
    #endregion


    private void Update()
    {
        #region �樫
        //�]�ߤ@�Ӧs����m�T�������
        Vector2 CharactersPosition = MoveT.position;
        CharactersPosition.x = CharactersPosition.x + MoveSpeed * Input.GetAxis("Horizontal");
        MoveT.position = CharactersPosition;
        #endregion

        JumpUp();
     
    }

 
    void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 JumpVel = new Vector2(0, JumpForce);
           JumpR.velocity = Vector2.up * JumpVel;
        }
    }
}
