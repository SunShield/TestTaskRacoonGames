using System.Collections.Generic;
using TestTask.DataLayer;
using TestTask.Gameplay.Score;
using TMPro;
using UnityEngine;

namespace TestTask.Gameplay.Entities.Visuals
{
    public class EntityWithNumberVisuals : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private List<TextMeshPro> _numberTexts;
        
        private MaterialPropertyBlock _propertyBlock;
        private Coroutine _flashRoutine;

        public void Setup(int power)
        {
            SetTexts(power);
            SetColor(power);
        }

        private void SetTexts(int power)
        {
            _numberTexts.ForEach(t => t.text = ScoreManager.Instance.GetScoreByPower(power).ToString());
        }

        private void SetColor(int power)
        {
            var color = GetColorByPower(power);
            _propertyBlock ??= new MaterialPropertyBlock();
            _propertyBlock.SetColor("_BaseColor", color);
            _renderer.SetPropertyBlock(_propertyBlock);
        }

        private Color GetColorByPower(int power)
        {
            var colorDb = GameDataProvider.Instance.ColorsDatabase;
            return power <= colorDb.Count ? colorDb[power - 1] : colorDb[^1];
        }
    }
}