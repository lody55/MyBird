using UnityEngine;
namespace MyBird
{
    //��� ��ũ�� ����
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        //��ũ�� �̵� �ӵ�
        [SerializeField]float moveSpeed = 5f;

        #endregion

        private void Update()
        {
            Move();
        }
        //����� �������� �̵� ��Ų��  , ����� x��ǥ�� -8.4���� ���ų� ������ x��ǥ�� ���ڸ��� ���´�
        private void Move()
        {
            if (GameManager.IsStart == false) return;
            //��� �Ѹ�
            if (transform.localPosition.x <= -8.4f)
            {
                transform.position = new Vector3(transform.position.x + 8.4f, transform.position.y, transform.position.z);
            }
            //��ũ�� �̵��ӵ�
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime,Space.World);

        }
    }
}