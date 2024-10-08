﻿using System;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [Serializable]
    public class CurrentData
    {
        [SerializeField] private int _fieldSize;
        [SerializeField] private int _animalCount;
        [SerializeField] private int _animalSpeed;
        [SerializeField] private bool _isNewData = true;

        public int FieldSize => _fieldSize;
        public int AnimalCount => _animalCount;
        public int AnimalSpeed => _animalSpeed;

        public bool IsNewData => _isNewData;

        public void SetConfig(int fieldSize, int animalCount, int animalSpeed)
        {
            _fieldSize = fieldSize;
            _animalCount = animalCount;
            _animalSpeed = animalSpeed;
            _isNewData = false;
        }
    }
}