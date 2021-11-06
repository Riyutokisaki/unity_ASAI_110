using UnityEngine;

/// <summary>
/// 角色的移動、跳躍
/// </summary>
public class Characters: MonoBehaviour
{
    //移動速度
    public float MoveSpeed = 0.1f;

    #region 跳躍
    //現在是否在跳躍
    public bool JumpingCheak = false;
    public float JumpForce;
    public Rigidbody2D JumpR;
    #endregion


    private void Update()
    {
        #region 行走
        //設立一個存取位置訊息的欄位
        Vector2 CharactersPosition = transform.position;
        CharactersPosition.x = CharactersPosition.x + MoveSpeed * Input.GetAxis("Horizontal");
        transform.position = CharactersPosition;
        #endregion

        #region 跳躍
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
