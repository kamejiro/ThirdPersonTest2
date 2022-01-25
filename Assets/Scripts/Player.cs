using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//必要コンポーネントの定義
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    //参照の定義
    Transform cam;
    Rigidbody rb;
    CapsuleCollider caps;
    //private Animator animator;
    
    //変数定義
    [SerializeField] float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //参照の初期化
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        caps = GetComponent<CapsuleCollider>();
        caps.center = new Vector3(0, 0.76f, 0);
        caps.radius = 0.23f;
        caps.height = 1.6f;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード入力を取得
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //animator.SetFloat("X", x * 50);
        //animator.SetFloat("Y", z * 50);

        //前進時向きを更新(y軸回転だけカメラの向きにする)
        if(z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
        }
        //後進時は遅くする。
        else if(z < 0)
        {
            z = z / 1.5f;
        }

        //移動(入力結果を反映)
        transform.position += transform.forward * z + transform.right * x;
    }
}
