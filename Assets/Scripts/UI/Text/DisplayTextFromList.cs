using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Text
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DisplayTextFromList : MonoBehaviour
    {
        [Header("Texts List")]
        [SerializeField] private List<string> textsList;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void DisplayTextById(float index)
        {
            _text.text = textsList[(int)index];
        }
    }
}