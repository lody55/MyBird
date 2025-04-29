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

        //점프
        private bool keyJump = false;   //점프키 인풋 체크
        [SerializeField]private float jumpForce = 5f;   //윗방향으로 주는 힘

        //회전
        private Vector3 birdRotation;
        //위로 올라갈 때 회전 속도
        [SerializeField]private float upRotateSpeed = 5f;
        //내려갈 때 회전 속도
        [SerializeField] private float downRotateSpeed = -5f;

        //이동
        //이동속도 - Transform  Translate(자동으로 오른쪽으로 이동
        [SerializeField]private float moveSpeed = 5f;

        //대기(아래로 떨어지지 않을 만큼의 힘)
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

            //인풋처리
            if (keyJump)
            {
                //Debug.Log("점프");
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
                //Debug.Log("포인트 획득");
                GameManager.Score++;

                
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log("장애물과 충돌했다");
                GameManager.IsDeath = true;
                animator.enabled = false;
                Invoke("ResultUI", 3f);

            }
            else if (collision.gameObject.CompareTag("Ground"))
            {
                //Debug.Log("Ground에 충돌했다");
                DieBird();
            }
        }

        private void Update()
        {
            //인풋처리
            InputBird();

            if (GameManager.IsStart == false || GameManager.IsDeath == true)
            {
                //버드 대기
                
                ReadyBird();
                return;
            }


            //버드 회전
            RotateBird();
                

            //오른쪽으로 이동
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
            //스페이스키 또는 마우스 왼클릭 받기
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            //게임 start전 점프 키 누르면 시작
            if(GameManager.IsStart == false && keyJump ==  true)
            {
                StartMove();
            }
        }
        //버드 대기
        void ReadyBird()
        {
            if (GameManager.IsDeath == true) return;
            //아래로 떨어지지 않을만큼의 힘을 준다
            if (rb2D.linearVelocity.y < 0f)
            {
                rb2D.linearVelocity = Vector2.up * readyForce;
            }
        }
        void JumpBird()
        {
            if (GameManager.IsDeath == true) return;
            //아래쪽에서 위쪽으로 힘을 준다
            //rb2D.AddForce(Vector2.up * 힘);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }
        void RotateBird()
        {
            //올라갈때 최대 +60도 회전 : upRoatateSpeed(속도)
            //내려갈때 최대 -60도 회전 : downRoatateSpeed(속도)
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
            // 여기에 씬 로드 코드를 넣는다
            resultUI.SetActive(true);
        }
        #endregion
    }
}