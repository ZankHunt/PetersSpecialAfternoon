using UnityEngine;

public class Tower : MonoBehaviour {

    private Transform target;

    private Animator ani;

    [Header("Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    public float damage = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    private bool upgraded = false;

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        ani = GetComponentInChildren<Animator>();
        ani.enabled = false;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            ani.enabled = true;
        } else
        {
            target = null;
            ani.enabled = false;
        }
    }
	
	void Update () {
        if (upgraded == false && UpgradeStats.upgradeTower == true)
        {
            if (gameObject.name.Contains("Tower01") || gameObject.name.Contains("Tower02"))
            {
                damage = damage * 2;
            }
            if (gameObject.name.Contains("Tower03") || gameObject.name.Contains("Tower04"))
            {
                fireRate = fireRate * 2;
            }
            upgraded = true;
        }
        if (target == null)
            return;

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        bullet.damage = damage;

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
