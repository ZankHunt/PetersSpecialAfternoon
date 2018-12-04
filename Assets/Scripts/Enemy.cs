using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float health = 1f;
    public int moneyValue = 10;
    public float speed = 10f;
    public float rotationSpeed = 5;

    [Header("Unity Setup")]
    public GameObject enemyDeathEffect;

    public GameObject endExplosion;
    public Vector3 positionOffset;

    int pathIndex = 0;
    Transform targetPathNode;
    GameObject pathGo;
    
    GameObject SoundW;

    private void Start()
    {
        pathGo = GameObject.Find("Waypoints");
        SoundW = GameObject.Find("Soundwave");
    }

    private void Update()
    {
        if(targetPathNode == null)
        {
            GetNextPathNode();
            if(targetPathNode == null)
            {
                ReachedGoal();
                return;
            }
        }
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distThisFrame)
        {
            targetPathNode = null;
        } else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void GetNextPathNode()
    {
        if (pathIndex < pathGo.transform.childCount)
        {
            targetPathNode = pathGo.transform.GetChild(pathIndex);
            pathIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
        }
    }

    void ReachedGoal()
    {
        GameObject effectIns = (GameObject)Instantiate(endExplosion, transform.position + positionOffset, transform.rotation);
        Destroy(effectIns, 10f);
        Destroy(SoundW);
        PlayerStats.Lives--;
        EnemySpawner.enemiesSpawned--;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        PlayerStats.Money += moneyValue;
        GameObject effectIns = (GameObject)Instantiate(enemyDeathEffect, transform.position + positionOffset, transform.rotation);
        Destroy(effectIns, 10f);

        EnemySpawner.enemiesSpawned--;

        Destroy(gameObject);
    }
}
