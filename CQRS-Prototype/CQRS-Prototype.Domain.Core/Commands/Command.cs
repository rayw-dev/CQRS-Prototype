using CQRS_Prototype.Domain.Core.Events;
using FluentValidation.Results;
using System;

namespace CQRS_Prototype.Domain.Core.Commands
{
    public abstract class Command : Message<Guid>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
