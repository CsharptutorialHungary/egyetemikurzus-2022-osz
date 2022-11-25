using System.Data;
using System.Reflection;
using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Exceptions;

namespace E22EDJ.Repositories;

public abstract class Repository<T> where T : Model
{
	
	private readonly GttContext _database = new();
	
	public List<T> GetAll()
	{
		return _database
			.Set<T>()
			.Where(entity => !entity.IsDeleted).ToList();
	}

	public T GetById(int id)
	{
		T? entity = _database
			.Set<T>()
			.Where(entity => !entity.IsDeleted && entity.Id == id)
			.FirstOrDefault();

		if (entity == null)
		{
			throw new EntityNotFoundException($"Could not find resource with id: {id}");
		}

		return entity;
	}
	
	public T GetByName(string name)
	{
		T? entity = _database
			.Set<T>()
			.Where(entity => !entity.IsDeleted && entity.Name == name)
			.FirstOrDefault();

		if (entity == null)
		{
			throw new EntityNotFoundException($"Could not find resource with name: {name}");
		}

		return entity;
	}
	
	public T Update<TModelUpdate>(int gameId, TModelUpdate updateValues) where TModelUpdate : IModelUpdate
	{
		T entity = GetById(gameId);

		foreach (PropertyInfo property in updateValues.GetType().GetProperties())
		{
			var propertyValue = property.GetValue(updateValues, null);
			if (propertyValue != null)
			{
				PropertyInfo? entityProperty = entity.GetType().GetProperty(property.Name);
				if (entityProperty == null)
				{
					throw new DataException($"Property doesn't exist on: {typeof(T)}");
				}
				entityProperty.SetValue(entity, propertyValue);
			}
		}

		_database.SaveChanges();

		return entity;
	}

	public void Delete(int id)
	{
		T entity = GetById(id);
		_database.Remove(entity);
		_database.SaveChanges();
	}
	
	
}