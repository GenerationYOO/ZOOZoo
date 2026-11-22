using System;
using System.Collections.Generic;
using System.Text;

namespace ZOOZoo.Application.Common.Results
{
    public sealed record ApplicationError
    {
        public ErrorType Type { get; }
        public string Code { get; }
        public string Description { get; }

        public ApplicationError(ErrorType type, string code, string description)
        {
            if (!Enum.IsDefined(type))
                throw new ArgumentOutOfRangeException(nameof(type), type, "Недопустимый тип ошибки.");

            ArgumentException.ThrowIfNullOrWhiteSpace(code);
            ArgumentException.ThrowIfNullOrWhiteSpace(description);

            Type = type;
            Code = code;
            Description = description;
        }

        public static ApplicationError NotFound(string code, string description) =>
            new(ErrorType.NotFound, code, description);

        public static ApplicationError ValidationError(string code, string description) =>
            new(ErrorType.ValidationError, code, description);

        public static ApplicationError BusinessRuleViolation(string code, string description) =>
            new(ErrorType.BusinessRuleViolation, code, description);

        public static ApplicationError Conflict(string code, string description) =>
            new(ErrorType.Conflict, code, description);

        public static ApplicationError ConfigurationError(string code, string description) =>
            new(ErrorType.ConfigurationError, code, description);
    }
    public enum ErrorType
    {
        NotFound,
        ValidationError,
        BusinessRuleViolation,
        Conflict,
        ConfigurationError
    }
}
