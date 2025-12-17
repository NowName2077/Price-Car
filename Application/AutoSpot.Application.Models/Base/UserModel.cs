namespace AutoSpot.Application.Models.Base;

public abstract record class UserModel(Guid Id, string Username): IModel<Guid>;