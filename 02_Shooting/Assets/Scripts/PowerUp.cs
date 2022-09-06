using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float dirChangeTime = 1.0f;  // 파워업 아이템의 이동방향이 바뀌는데 걸리는 시간
    public float moveSpeed = 0.5f;  // 이동속도
    public float selfDestroyTime = 10.0f;   // 스스로 없어지는 데 걸리는 시간

    Player player;  // 파워업 아이템의 이동방향 설정에 필요한 플레이어
    Vector2 dir;    // 현재 이동 방향
    WaitForSeconds waitTime;    // 코루틴에서 사용하기 위한 기다리는 시간 간격
    private void Start()
    {
        waitTime = new WaitForSeconds(dirChangeTime);   // dirChangeTime만큼 기다리도록 waitTime 미리 생성
        player = FindObjectOfType<Player>();            // Player 타입을 찾기(무조건 한개만 찾기 때문에 여러개가 있을 경우 어떤 것이 들어올 지는 알 수 없다.
        SetRandomDir();         // 랜덤하게 현재 이동 방향 설정
        StartCoroutine(DirChange());    // 코루틴 실행해서 일정 시간 간격으로 이동 방향 변경되게 설정
        Destroy(this.gameObject, selfDestroyTime);      // selfDestroyTime초 후에 스스로 사라지기
    }
    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * dir);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Vector2.Reflect(dir, collision.contacts[0].normal);
        }
    }

    IEnumerator DirChange()
    {
        while (true)
        {
            yield return waitTime;
            SetRandomDir(false);
        }
    }
    void SetRandomDir(bool allRandom = true)    // 디폴트 파라메터. 값을 지정하지 않으면 디폴트 값이 대신 들어간다.
    {
        if(allRandom)
        {

        dir = Random.insideUnitCircle;
        dir = dir.normalized;
        }
        else
        {
            Vector2 playerToPowerUp = transform.position - player.transform.position;
            playerToPowerUp = playerToPowerUp.normalized;
            if( Random.value < 0.6f)    // 60% 확률로 플레이어 반대방향으로 이동
            {
            dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;    // playerToPowerUp 벡터를 z축으로 -90~+90만큼 회전시켜서 dir에 넣기
            }
            else    // 40% 확률로 플레이어 방향으로 이동
            {
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * -playerToPowerUp;
            }
        }
    }

   
}
