#region Namespaces/Directives

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class BaseEnemy : MonoBehaviour, IDamageable
{
    #region Declarations

    [Header("Movement Settings")]
    [SerializeField] private Vector3 _patrolPositionOne;
    [SerializeField] private Vector3 _patrolPositionTwo;
    [SerializeField] private float _movementSpeed;

    private Vector3 _targetPosition;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        _targetPosition = _patrolPositionOne;
    }

    private void Update()
    {
        Move();
    }

    #endregion

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _targetPosition) < 0.2f)
        {
            if(_targetPosition == _patrolPositionOne)
            {
                _targetPosition = _patrolPositionTwo;
            }
            else
            {
                _targetPosition = _patrolPositionOne;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy damaged");
    }
}
