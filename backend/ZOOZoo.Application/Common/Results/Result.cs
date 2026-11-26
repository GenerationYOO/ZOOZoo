using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZOOZoo.Application.Common.Results
{
    public sealed class Result<T>
    {
        private readonly T? value;

        public ApplicationError? Error { get; }
        public bool IsSuccess => Error is null;
        public bool IsFailure => !IsSuccess;

        public T Value => IsSuccess ? 
            value! : throw new InvalidOperationException("У результата с ошибкой нет значения");

        private Result(T? value, ApplicationError? error)
        {
            this.value = value;
            Error = error;
        }

        public static Result<T> Success(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            return new Result<T>(value, null);
        }

        public static Result<T> Failure(ApplicationError error)
        {
            ArgumentNullException.ThrowIfNull(error);
            return new Result<T>(default, error);
        }
    }
}

public readonly record struct Unit
{
    public static Unit Value => default;
}
