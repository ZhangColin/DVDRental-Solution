using System;
using System.Collections.Generic;

namespace DVDRenatal.Infrastructure.Domain
{
    public static class DomainEvents
    {
        [ThreadStatic] private static List<Delegate> _actions;

        private static List<Delegate> Actions
        {
            get
            {
                if (_actions == null)
                {
                    _actions = new List<Delegate>();
                }
                return _actions;
            }
        }

        public static IDisposable Register<T>(Action<T> callback)
        {
            Actions.Add(callback);
            return new DomainEventRegistrationRemover(() => Actions.Remove(callback));
        }


        public static void Raise<T>(T eventArgs)
        {
            foreach (var action in Actions)
            {
                Action<T> typedAction = action as Action<T>;
                if (typedAction!=null)
                {
                    typedAction(eventArgs);
                }
            }
        }

        private sealed class DomainEventRegistrationRemover: IDisposable
        {
            private readonly Action _toCallOnDispose;

            public DomainEventRegistrationRemover(Action toCall)
            {
                _toCallOnDispose = toCall;
            }

            public void Dispose()
            {
                _toCallOnDispose();
            }
        }
    }
}