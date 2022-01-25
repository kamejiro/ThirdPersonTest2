using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    //�Q�Ƃ̒�`
    GameObject player;
    Camera cam;


    //�ϐ���`
    //�c���x�̊p�x����
    float angleUp = 60f;
    float angleDown = 0;
    //�J�������x��Ă��Ă����B���R�͂킩���B0���Ƃ��Ă����Ȃ��B
    public float attenuate = 5f;
    //���_���x
    [SerializeField] float rotate_speed = 3;
    //�J�����ƃv���C���[�̋������X�N���[���Œ���
    [SerializeField] float scroll;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�Ƃ̏�����
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�ɒx��Ēǂ������鏈��(�v���C���[�̈ʒu�Ǝ��̈ʒu��attenuate�Ő��`�ߎ�)
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * attenuate);
        //�����v���C���[�ɒx�ꂸ�ɒǂ������鏈��
        //transform.position = player.transform.position;

        //�J�����ƃv���C���[�̋���(z����)�̓X�N���[���Œ����\
        scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.transform.localPosition += new Vector3(0, 0, scroll);
        //�X�N���[���ŃJ�������v���C���[�̑O�ɗ��邱�Ƃ��Ȃ��悤�ɂ���B
        if(cam.transform.localPosition.z > 0)
        {
            cam.transform.localPosition
                = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, 0);
        }

        //�}�E�X�̓��͌��ʂ𔽉f
        transform.eulerAngles
            += new Vector3(Input.GetAxis("Mouse Y") * rotate_speed, Input.GetAxis("Mouse X") * rotate_speed, 0);

        //x����]�i�c�������x�j�ɐ�����������B
        float angleX = transform.eulerAngles.x;
        if(angleX >= 180)
        {
            angleX = angleX - 360;
        }
        transform.eulerAngles = new Vector3(Mathf.Clamp(angleX, angleDown, angleUp), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
