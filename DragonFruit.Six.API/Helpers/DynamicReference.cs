// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.API.Helpers
{
    public class DynamicReference<T> where T : class
    {
        private readonly WeakReference _reference = new WeakReference(null, false);
        private readonly Func<T> _valueFactory;

        public DynamicReference(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
        }

        public DynamicReference()
        {
            _valueFactory = () => (T)Activator.CreateInstance(typeof(T));
        }

        public T Value
        {
            get
            {
                if (_reference.IsAlive)
                {
                    return (T)_reference.Target;
                }

                var newValue = _valueFactory.Invoke();
                _reference.Target = newValue;
                return newValue;
            }
        }
    }

}
