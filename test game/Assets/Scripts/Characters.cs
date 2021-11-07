using UnityEngine;

/// <summary>
/// 角色的移動、跳躍
/// </summary>
public class Characters: MonoBehaviour
{
    //移動速度
    public float MoveSpeed = 0.1f;
    public Transform MoveT;

    #region 跳躍
    public bool JumpingCheak = false;
    public float JumpForce = 5f;
    public Rigidbody2D JumpR;
    #endregion


    private void Update()
    {
        #region 行走
        //設立一個存取位置訊息的欄位
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
