using System;
using System.Collections.Generic;
using System.Text;

namespace EliottChen.CSharpToolkit
{
    /// <summary>
    /// State machine object responsible to handle state, check transitions, change state, and update thems.
    /// </summary>
    /// <typeparam name="TOwner"> The type of the StateMachine owner</typeparam>
    public class StateMachine<TOwner>
    {
        public bool IsInTransition => _isInTransition;
        public State<TOwner>? CurrentState => _current;

        private State<TOwner>? _current;
        private readonly TOwner _owner;
        private bool _isInTransition = false;


        public StateMachine(TOwner owner)
        {
            _owner = owner;
        }

        public void ChangeState(State<TOwner> pNextState)
        {
            _isInTransition = true;
            _current?.OnExit();
            _current?.EmitExited();
            _current = pNextState;
            _current?.OnEnter();
            _current?.EmitEntered();
            _isInTransition = false;
        }

        public void Update(float pDelta)
        {
            if (_current == null){ return; }

            if (_isInTransition){ return; }
            State<TOwner>? next = _current?.GetTransition();
            if (next != null) { ChangeState(next); return; }
            _current?.OnUpdate(pDelta);
        }

        public void FixedUpdate(float pDelta)
        {
            if (_current == null){ return; }

            if (_isInTransition) { return; }
            _current?.OnFixedUpdate(pDelta);
        }
    }

    public abstract class State<TOwner>
    {
        protected TOwner _Owner;

        public Action? onEnter;
        public Action? onExit;

        public State(TOwner owner)
        {
            _Owner = owner;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public abstract State<TOwner> GetTransition();
        public abstract void OnUpdate(float dt);
        public abstract void OnFixedUpdate(float pDeltaTime);

        public void EmitEntered() { onEnter?.Invoke(); }
        public void EmitExited() { onExit?.Invoke(); }
    }

    public interface IGetStateMachine<T>
    {
        public StateMachine<T> GetStateMachine();
    }
}
