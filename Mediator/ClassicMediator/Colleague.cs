using System;

namespace MediatorPattern.ClassicMediator
{
    public abstract class Colleague
    {
        protected readonly Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public virtual void Send (string message)
        {
            mediator.Send(message, this);
        }
        public abstract void HandleNotification(string message);
    }
}