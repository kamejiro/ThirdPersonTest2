using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�K�v�R���|�[�l���g�̒�`
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    //�Q�Ƃ̒�`
    Transform cam;
    Rigidbody rb;
    CapsuleCollider caps;
    //private Animator animator;
    
    //�ϐ���`
    [SerializeField] float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�Ƃ̏�����
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
        //�L�[�{�[�h���͂��擾
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //animator.SetFloat("X", x * 50);
        //animator.SetFloat("Y", z * 50);

        //�O�i���������X�V(y����]�����J�����̌����ɂ���)
        if(z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
        }
        //��i���͒x������B
        else if(z < 0)
        {
            z = z / 1.5f;
        }

        //�ړ�(���͌��ʂ𔽉f)
        transform.position += transform.forward * z + transform.right * x;
    }
}
