using UnityEngine;
namespace MyBird
{
    //카메라 제어 - 플레이어 이동에 따라 같이 이동한다
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //플레이어 오브젝트
        public Transform player;

        //카메라 위치 offset
        [SerializeField] private float offsetX = 1.5f;
        #endregion

        private void Update()
        {
            FollowPlayer();
        }
        //카메라의 위치를 플레이어의 위치에서 z방향으로 -10만큼 위치하게 만든다
        void FollowPlayer()
        {
            this.transform.position = new Vector3(player.position.x+offsetX, transform.position.y, transform.position.z);
        }
    }
}