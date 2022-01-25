using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    //参照の定義
    GameObject player;
    Camera cam;


    //変数定義
    //縦感度の角度制限
    float angleUp = 60f;
    float angleDown = 0;
    //カメラが遅れてついていく。理由はわからん。0だとついていかない。
    public float attenuate = 5f;
    //視点感度
    [SerializeField] float rotate_speed = 3;
    //カメラとプレイヤーの距離をスクロールで調整
    [SerializeField] float scroll;

    // Start is called before the first frame update
    void Start()
    {
        //参照の初期化
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //軸がプレイヤーに遅れて追いかける処理(プレイヤーの位置と軸の位置をattenuateで線形近似)
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * attenuate);
        //軸がプレイヤーに遅れずに追いかける処理
        //transform.position = player.transform.position;

        //カメラとプレイヤーの距離(z方向)はスクロールで調整可能
        scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.transform.localPosition += new Vector3(0, 0, scroll);
        //スクロールでカメラがプレイヤーの前に来ることがないようにする。
        if(cam.transform.localPosition.z > 0)
        {
            cam.transform.localPosition
                = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, 0);
        }

        //マウスの入力結果を反映
        transform.eulerAngles
            += new Vector3(Input.GetAxis("Mouse Y") * rotate_speed, Input.GetAxis("Mouse X") * rotate_speed, 0);

        //x軸回転（縦方向感度）に制限を加える。
        float angleX = transform.eulerAngles.x;
        if(angleX >= 180)
        {
            angleX = angleX - 360;
        }
        transform.eulerAngles = new Vector3(Mathf.Clamp(angleX, angleDown, angleUp), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
