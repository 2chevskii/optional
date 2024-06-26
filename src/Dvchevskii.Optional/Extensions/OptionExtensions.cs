﻿using System.Diagnostics.CodeAnalysis;

namespace Dvchevskii.Optional.Extensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class OptionExtensions
    {
        public static (Option<T>, Option<U>) Unzip<T, U>(this Option<(T, U)> self) =>
            self.IsNone
                ? (Option.None<T>(), Option.None<U>())
                : (Option.Some(self.Unwrap().Item1), Option.Some(self.Unwrap().Item2));

        public static Option<T> Flatten<T>(this Option<Option<T>> self) =>
            self.MapOrElse(val => val, Option.None<T>);

        public static Option<T> AsSome<T>(this T self) => Option.Some(self);

        public static Option<T> AsNone<T>(this T _) => Option.None<T>();
    }
}
