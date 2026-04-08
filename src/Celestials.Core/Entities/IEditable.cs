namespace Celestials.Core.Entities;

public interface IEditable<TUpdateModel> : IUpdatable<TUpdateModel>, IDeletable
    where TUpdateModel : notnull;
