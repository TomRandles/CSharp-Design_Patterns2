using System;

namespace MediatorPattern.ClassicMediator
{
    public abstract class AlternativeColleague
    {
        protected Chatroom mediator;

        internal void SetMediator(Chatroom mediator)
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