using UnityEngine;
namespace MyBird
{
    //ī�޶� ���� - �÷��̾� �̵��� ���� ���� �̵��Ѵ�
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //�÷��̾� ������Ʈ
        public Transform player;

        //ī�޶� ��ġ offset
        [SerializeField] private float offsetX = 1.5f;
        #endregion

        private void Update()
        {
            FollowPlayer();
        }
        //ī�޶��� ��ġ�� �÷��̾��� ��ġ���� z�������� -10��ŭ ��ġ�ϰ� �����
        void FollowPlayer()
        {
            this.transform.position = new Vector3(player.position.x+offsetX, transform.position.y, transform.position.z);
        }
    }
}