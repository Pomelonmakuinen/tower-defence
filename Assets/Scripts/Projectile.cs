using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public float damage;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void Seek(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"Hitting enemy for {damage} damage");
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("No Enemy component found on target.");
        }

        Destroy(gameObject);
    }

}
