using System;
using System.Linq;
using UnityEngine;

namespace LiftMeUp
{
    public class LiftExpressionManager : MonoBehaviour
    {
        [field: SerializeField] public Expression[] AvailableExpressions { get; private set; }

        public static LiftExpressionManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            throw new NotImplementedException();
        }

        public static Sprite GetSpriteFromState(State state)
        {
            var expression = Instance.AvailableExpressions.FirstOrDefault(expression => expression.State == state);

            return expression == null ? Instance.AvailableExpressions[0].Sprite : expression.Sprite;
        }

        [Serializable]
        public class Expression
        {
            public State State;
            public Sprite Sprite;
        }

        public enum State
        {
            Normal = 0,
            Satisfied = 1,
            Happy = 2,
            VeryHappy = 3,
            Ecstatic = 4,
            Bored = 5,
            Upset = 6,
            Sad = 7,
            Angry = 8,
            Scared = 9,
            Surprised = 10,
        }
    }
}
