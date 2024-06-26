using System;

// ReSharper disable InconsistentNaming

namespace Dvchevskii.Optional
{
    public sealed class Some<T> : Option<T>
    {
        private readonly T _value;

        public override bool IsSome => true;
        public override bool IsNone => false;

        private Some(T value)
        {
            _value = value;
        }

        public static Some<T> From(T value) => new Some<T>(value);

        public override bool IsSomeAnd(Predicate<T> predicate) => predicate(_value);

        public override Option<T> Inspect(Action<T> inspector)
        {
            inspector(_value);
            return this;
        }

        public override T Expect(string message) => _value;

        public override T Unwrap() => _value;

        public override T UnwrapOr(T defaultValue) => _value;

        public override T UnwrapOrElse(Func<T> defaultValueFactory) => _value;

        public override T UnwrapOrDefault() => _value;

        public override Option<U> Map<U>(Func<T, U> mapper) => new Some<U>(mapper(_value));

        public override U MapOr<U>(Func<T, U> mapper, U defaultValue) => mapper(_value);

        public override U MapOrElse<U>(Func<T, U> mapper, Func<U> defaultValueFactory) =>
            mapper(_value);

        public override Option<U> And<U>(Option<U> optionB) => optionB;

        public override Option<U> AndThen<U>(Func<T, Option<U>> optionBFactory) =>
            optionBFactory(_value);

        public override Option<T> Filter(Predicate<T> predicate) =>
            predicate(_value) ? Some(_value) : None<T>();

        public override Option<T> Or(Option<T> optionB) => this;

        public override Option<T> OrElse(Func<Option<T>> optionBFactory) => this;

        public override Option<T> XOr(Option<T> optionB) => optionB.IsSome ? None<T>() : this;

        public override Option<(T, U)> Zip<U>(Option<U> other) =>
            other.IsNone ? None<(T, U)>() : Some((Unwrap(), other.Unwrap()));

        public override Option<R> ZipWith<U, R>(Option<U> other, Func<T, U, R> func) =>
            other.IsNone ? None<R>() : Some(func(Unwrap(), other.Unwrap()));

        public override string ToString()
        {
            return $"Some<{UnderlyingType.Name}>({_value})";
        }
    }
}
