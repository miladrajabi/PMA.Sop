using System;

namespace PMA.Sop.Framework.Commands
{
    public class CommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public CommandResult Dispatch(ICommand command)
        {
            var type = typeof(CommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            if (handler == null) return new CommandResult();
            CommandResult result = handler.Handle((dynamic)command);
            return result;
        }
    }
}
