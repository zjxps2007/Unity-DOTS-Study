using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class Spawner_DOTS : MonoBehaviour
{
    [SerializeField] private GameObject _simpleCube = null;
    [SerializeField] private int        _spawnCount = 100000;
    [SerializeField] private float      _halfWidth = 50f;
    [SerializeField] private float      _halfHeight = 50f;

    [Header("[For DOTS")]
    [SerializeField] private float _rotationSpeed = 100f;

    private void Awake()
    {
        m_EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        var radianAngle = _rotationSpeed * Mathf.Deg2Rad;

        for (int i = 0; i < _spawnCount; ++i)
        {
            var entity = m_EntityManager.Instantiate(m_PrefabEntity);

            m_EntityManager.SetComponentData<Translation>(entity, new Translation()
            {
                Value = new float3(UnityEngine.Random.Range(-_halfWidth, _halfWidth), UnityEngine.Random.Range(-_halfHeight, _halfHeight), UnityEngine.Random.Range(-_halfHeight, _halfHeight))
            });

            m_EntityManager.AddComponentData<DOTS_RotatorData>(entity, new DOTS_RotatorData() { 
                _speed = radianAngle,
            });
        }
    }

    private EntityManager   m_EntityManager;
    private Entity          m_PrefabEntity;

}
