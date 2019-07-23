
using Logger.Models.Enumerations;

namespace Logger.Models.Interfaces
{
   public interface IAppender
    {
        ILayout Layout { get; }
        Level level { get; }

        void Append(IError error);

    }
}
