using Unity.VisualScripting;
using UnityEngine;
namespace MyBird
{
    //��� ������ - 1�ʸ��� ����ϳ��� ����
    public class PipeSpawner : MonoBehaviour
    {
        #region Variables
        public GameObject PipePrefab;
        [SerializeField] float time = 1f;
        private float countdown = 0f;

        //���� ��ġ
        private float spawnMaxY = 2.1f;
        private float spawnMinY = -2.6f;

        //���� ����
        [SerializeField] private float maxSpawnTime = 1.05f;
        [SerializeField] private float minSpawnTime = 0.95f;

        //�ִϸ�����
        
        #endregion

        //1�ʸ��� ��� �ϳ��� ����, ���� ���۽� 
        private void Update()
        {
            if (GameManager.IsStart == false|| GameManager.IsDeath == true) return;
            countdown += Time.deltaTime;
            if (countdown >= time)
            {
                SpawnPipe();
                countdown = 0f;
                time = Random.Range(minSpawnTime, maxSpawnTime);
            }
            
            
        }
        void SpawnPipe()
        {
            float spawnY = transform.position.y + Random.Range(spawnMinY, spawnMaxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);

            Instantiate(PipePrefab, spawnPosition, Quaternion.identity);
        }
    }
}