using UnityEngine;
namespace MyBird
{
    //������ų���� �浹�ϴ� ��� �浹ü�� Destroy�ȴ�
    //ų�� �����ص� 
    //1. �浹���� �ʴ´�  2. �浹���� kill���� �ʴ´�
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);

        }
    }
}