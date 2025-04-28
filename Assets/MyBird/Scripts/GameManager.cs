using UnityEngine;
using UnityEngine.InputSystem;
namespace MyBird
{
    //게임의 전체 플로우를 관리하는 클래스
    //대기 >> 이동 >> 죽음(결과처리)
    //static 처리 : 싱글톤 클래스 , 변수를 static처리
    public class GameManager : MonoBehaviour
    {
        #region Property
        public static bool IsStart { get; set; }

        #endregion

        private void Start()
        {
            
            //초기화
            IsStart = false;

        }
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                IsStart = true;
            }
        }
    }
}