using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E22EDJ.DBModels;

public abstract class Model
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public bool IsDeleted { get; set; }
}