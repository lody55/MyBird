using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
namespace MyBird
{

    public class Player : MonoBehaviour
    {
        #region Field
        //Variables
        private Rigidbody2D rb2D;

        public Animator animator;

        //����
        private bool keyJump = false;   //����Ű ��ǲ üũ
        [SerializeField]private float jumpForce = 5f;   //���������� �ִ� ��

        //ȸ��
        private Vector3 birdRotation;
        //���� �ö� �� ȸ�� �ӵ�
        [SerializeField]private float upRotateSpeed = 5f;
        //������ �� ȸ�� �ӵ�
        [SerializeField] private float downRotateSpeed = -5f;

        //�̵�
        //�̵��ӵ� - Transform  Translate(�ڵ����� ���������� �̵�
        [SerializeField]private float moveSpeed = 5f;

        //���(�Ʒ��� �������� ���� ��ŭ�� ��)
        [SerializeField] private float readyForce = 1f;


        public GameObject readyUI;
        public GameObject resultUI;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb2D = this.GetComponent<Rigidbody2D>();
            resultUI.SetActive(false);
        }

        private void FixedUpdate()
        {

            //��ǲó��
            if (keyJump)
            {
                //Debug.Log("����");
                JumpBird();
                keyJump = false;
            }


        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.gameObject.CompareTag("Point"))
            {
                //Debug.Log("����Ʈ ȹ��");
                GameManager.Score++;

                
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log("��ֹ��� �浹�ߴ�");
                GameManager.IsDeath = true;
                animator.enabled = false;
                Invoke("ResultUI", 3f);

            }
            else if (collision.gameObject.CompareTag("Ground"))
            {
                //Debug.Log("Ground�� �浹�ߴ�");
                DieBird();
            }
        }

        private void Update()
        {
            //��ǲó��
            InputBird();

            if (GameManager.IsStart == false || GameManager.IsDeath == true)
            {
                //���� ���
                
                ReadyBird();
                return;
            }


            //���� ȸ��
            RotateBird();
                

            //���������� �̵�
            MoveBird();
        }

        private void MoveBird()
        {

            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime,Space.World);
        }

        // Update is called once per frame
       
       
        #endregion
        #region User Method


        private void InputBird()
        {
            if (GameManager.IsDeath == true) return;
            //�����̽�Ű �Ǵ� ���콺 ��Ŭ�� �ޱ�
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            //���� start�� ���� Ű ������ ����
            if(GameManager.IsStart == false && keyJump ==  true)
            {
                StartMove();
            }
        }
        //���� ���
        void ReadyBird()
        {
            if (GameManager.IsDeath == true) return;
            //�Ʒ��� �������� ������ŭ�� ���� �ش�
            if (rb2D.linearVelocity.y < 0f)
            {
                rb2D.linearVelocity = Vector2.up * readyForce;
            }
        }
        void JumpBird()
        {
            if (GameManager.IsDeath == true) return;
            //�Ʒ��ʿ��� �������� ���� �ش�
            //rb2D.AddForce(Vector2.up * ��);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }
        void RotateBird()
        {
            //�ö󰥶� �ִ� +60�� ȸ�� : upRoatateSpeed(�ӵ�)
            //�������� �ִ� -60�� ȸ�� : downRoatateSpeed(�ӵ�)
            float rotateSpeed = 0f;
            if(rb2D.linearVelocity.y > 0f)
            {
                rotateSpeed = upRotateSpeed;
            }
            else if(rb2D.linearVelocity.y <0f)
            {
                rotateSpeed = downRotateSpeed;
            }
            birdRotation = new Vector3(0f, 0f,Mathf.Clamp((birdRotation.z + rotateSpeed),-60f,60f));
            this.transform.eulerAngles = birdRotation;
        }
        void DieBird()
        {
            GameManager.IsDeath = true;
            animator.enabled = false;
        }
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
        private void ResultUI()
        {
            // ���⿡ �� �ε� �ڵ带 �ִ´�
            resultUI.SetActive(true);
        }
        #endregion
    }
}